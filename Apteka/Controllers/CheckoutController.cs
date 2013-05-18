using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Apteka.ViewModels;
using Apteka.Logic;
using System.Data;
using System.Xml;
using System.Net.Mail;
using System.Net;

namespace Apteka.Controllers
{
    public class CheckoutController : Controller
    {
        private db_lekiContext db = new db_lekiContext();
        //
        // GET: /Checkout/

        public ActionResult AddressAndPayment()
        {
            if (User.Identity.IsAuthenticated)
            {
                var model = new ShoppingCartViewModel();
                var cart = ShoppingCart.GetCart(this.HttpContext);

                model.User = db.t_users.Where(x => x.Login == User.Identity.Name).Single();
                model.CartItems = cart.GetCartItems();
                model.CartTotal = cart.GetTotal();
                model.CartTotalNumber = cart.GetCount();
                return View(model);
            }
            else
            {
                return RedirectToAction("LogOn", "Account");
            }
        }

        [HttpPost]
        public ActionResult AddressAndPayment(string paymentOption, string transportOption)
        {
            var model = new ShoppingCartViewModel();
            var cart = ShoppingCart.GetCart(this.HttpContext);
            model.CartItems = cart.GetCartItems();

            var prod = model.CartItems.Select(x => x.t_produkty.Id);
            //for kazdy produkt
            foreach (var p in prod)
            {
                //sprawdz czy sa te produkty
                var dbProd = db.t_produkty.Where(x => x.Id == p).Single();
                if (dbProd.ilosc < model.CartItems.Where(x => x.ProduktId == p).Single().Count)
                {
                    return RedirectToAction("Index","Home");//informacja o bledzie
                }
                else
                {
                    //zmiejszyc ilosc lub usunac (o ilosc kupionych)
                    if (dbProd.ilosc == model.CartItems.Where(x => x.ProduktId == p).Single().Count)
                    {
                        db.Entry(dbProd).State = EntityState.Deleted;
                        db.SaveChanges();
                    }
                    else
                    {
                        dbProd.ilosc -= model.CartItems.Where(x => x.ProduktId == p).Single().Count;
                        db.Entry(dbProd).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }

            }

            var shops = model.CartItems.Select(x => x.t_produkty.sklep_id).Distinct();
            //for kazdy sklep
            foreach (var s in shops)
            {
                //wyciagnac produkty
                var prodByShop = model.CartItems.Where(x => x.t_produkty.sklep_id == s);
                //podac adres
                var userAddr = db.t_users.Where(x => x.Login == User.Identity.Name).Single();
                //podac opcje przesylki
                string transportOptString;
                switch (transportOption)
                {
                    case "0": transportOptString = "Odbiór własny (0 PLN)";
                        break;
                    case "10": transportOptString = "Przesyłka kurierska (10 PLN)";
                        break;
                    case "7": transportOptString = "Przesyłka pocztowa (list polecony) (7 PLN)";
                        break;
                    case "5": transportOptString = "Przesyłka pocztowa (list zwykły) (5 PLN)";
                        break;
                    default: transportOptString = "Inny typ wysyłki (NaNa PLN)";
                        break;
                }
                //podac opcje zaplaty
                string paymentOptString;
                switch (paymentOption)
                {
                    case "0": paymentOptString = "W aptece (0 PLN)";
                        break;
                    case "5": paymentOptString = "Przelew na konto (5 PLN)";
                        break;
                    case "10": paymentOptString = "Przy odbiorze (10 PLN)";
                        break;
                    default: paymentOptString = "Inny forma płatności (NaNa PLN)";
                        break;
                }
                //parsowanie do xmla
                XmlDocument doc = new XmlDocument();
                //produkty (xml)
                XmlElement el = (XmlElement)doc.AppendChild(doc.CreateElement("Produkty"));
                
                foreach (var pp in prodByShop)
                {
                    XmlElement elP = (XmlElement)el.AppendChild(doc.CreateElement("ID:"+Convert.ToString(pp.ProduktId)));
                    elP.AppendChild(doc.CreateElement("Nazwa")).InnerText = pp.t_produkty.t_leki.nazwa_char;
                    elP.AppendChild(doc.CreateElement("Ilosc")).InnerText = Convert.ToString(pp.Count);
                    elP.AppendChild(doc.CreateElement("Cena")).InnerText = Convert.ToString(pp.t_produkty.cena);
                }
                //transport (xml)
                el.AppendChild(doc.CreateElement("Transport")).InnerText = transportOptString;
                //platnosc (xml)
                el.AppendChild(doc.CreateElement("Platnosc")).InnerText = paymentOptString;
                //adres wysylki (xml)
                XmlElement elW = (XmlElement)el.AppendChild(doc.CreateElement("AdresWysylki"));
                elW.AppendChild(doc.CreateElement("Imie")).InnerText = userAddr.Imie;
                elW.AppendChild(doc.CreateElement("Nazwisko")).InnerText = userAddr.Nazwisko;
                elW.AppendChild(doc.CreateElement("Adres")).InnerText = userAddr.Ulica+" "+userAddr.KodPocztowy+" "+userAddr.Miasto+" "+userAddr.NumerDomu+"/"+userAddr.NumerMieszkania;
                elW.AppendChild(doc.CreateElement("email")).InnerText = userAddr.email;
                Console.WriteLine(doc.OuterXml);
                //dodac zamowienie (user_id,sklep_id,xml,status)
                t_zamowienia NewZam = new t_zamowienia();
                NewZam.lek_data = doc.OuterXml;
                NewZam.sklep_id = s;
                NewZam.status = "nowe";
                NewZam.user_id = userAddr.Id;
                db.Entry(NewZam).State = EntityState.Added;
                db.SaveChanges();

                //wyslac jakiegos maila do kupujacego
                var usr = db.t_users.First(a => a.Login == User.Identity.Name);
                MailMessage mail = new MailMessage();
                NetworkCredential basicCredential =
                new NetworkCredential("aptegropl", "1q2w3e4r%T");
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("aptegropl@gmail.com");
                mail.To.Add(usr.email);
                mail.Subject = "Potwierdzenie zakupu";
                mail.IsBodyHtml = true;
                mail.Body = "Nazwa sklepu: "+ db.t_sklepy.Where(x=>x.Id==s).Single().Nazwa
                    +". Status zamówienia: <b>"+ NewZam.status+"</b>";

                SmtpServer.Host = "smtp.gmail.com";
                SmtpServer.EnableSsl = true;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = basicCredential;
                SmtpServer.Send(mail);
            }

            //wyczyscic koszyk
            cart.EmptyCart();

            return RedirectToAction("Index","Home");
        }

    }
}
