using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Apteka.Common;
using System.Net.Mail;
using System.Net;

namespace Apteka.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        private db_lekiContext db = new db_lekiContext();
        private static string CashForLekData;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Zamowienia()
        {
            var zam = db.t_zamowienia.Where(a => a.t_sklepy.t_users.Login == User.Identity.Name).OrderBy(a => a.Id);            

            return View(zam.ToList());
        }


        public ActionResult ZmianaStatusu(int id)
        {
            var zam = db.t_zamowienia.Find(id);
            CashForLekData = zam.lek_data;
            ViewData["changeDuration"] = new SelectList(Status.getDurationListDD, "Key", "Value", zam.Id);
            return View(zam);
        }

        //
        // POST: 

        [HttpPost]
        public ActionResult ZmianaStatusu(t_zamowienia zam)
        {
            if (ModelState.IsValid)
            {
                var usr = db.t_users.Find(zam.user_id);
                var skl = db.t_sklepy.Find(zam.sklep_id);

                zam.lek_data = CashForLekData;

                zam.t_users = usr;
                zam.t_sklepy = skl;                

                var s = Status.getDurationListDD;
                var a = ViewData["changeduration"];
                db.Entry(zam).State = EntityState.Modified;
                db.SaveChanges();

                MailMessage mail = new MailMessage();
                NetworkCredential basicCredential =
                new NetworkCredential("aptegropl", "1q2w3e4r%T");
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("aptegropl@gmail.com");
                mail.To.Add(zam.t_users.email);

                // dla nowego raczej nie będzie mail tutaj przesyłany a przy checkoutcie
                if (zam.status.Equals("nowe"))
                {
                    mail.Subject = "Zgłoszenie zostało zarejestrowane w systemie";
                    mail.IsBodyHtml = true;
                    mail.Body = string.Format("Zgłoszenie o numerze {0} zostało zarejestrowane.<br/> Prosimy o wpłacenie należytej kwoty na poniższy numer rachunku bankowego<br/>{1}<br/><br/>Użytkownik: {2}<br/>Sklep: {3}", zam.Id.ToString(), zam.Id.ToString(), zam.t_users.Login, zam.t_sklepy.Nazwa);
                }
                else if (zam.status.Equals("wpłata zrealizowana"))
                {
                    mail.Subject = "Wpłata została zarejestrowane";
                    mail.IsBodyHtml = true;
                    mail.Body = string.Format("Wpłata dla zgłoszenia o numerze {0} została zarejestrowana.",zam.Id.ToString());
                }
                else if (zam.status.Equals("do realizacji"))
                {
                    mail.Subject = "Zgłoszenie zostało przeznaczone do realizacji";
                    mail.IsBodyHtml = true;
                    mail.Body = string.Format("Sklep przeznaczył zgłoszenie o numerze {0} do realizacji.", zam.Id.ToString());
                }
                else if (zam.status.Equals("wysłano"))
                {
                    mail.Subject = "Zgłoszenie zostało Wysłane";
                    mail.IsBodyHtml = true;
                    mail.Body = string.Format("Sklep wysłał przesyłkę/ki z zamówienia o numerze {0}.", zam.Id.ToString());
                }
                else if (zam.status.Equals("wstrzymano"))
                {
                    mail.Subject = "Zgłoszenie zostało wstrzymane";
                    mail.IsBodyHtml = true;
                    mail.Body = string.Format("Sklep wstrzymał realizację zgłoszenia {0}", zam.Id.ToString());
                }
                else if (zam.status.Equals("anulowano"))
                {
                    mail.Subject = "Zgłoszenie zostało anulowane";
                    mail.IsBodyHtml = true;
                    mail.Body = string.Format("Sklep anulował realizację zgłoszenia {0}", zam.Id.ToString());
                }

                SmtpServer.Host = "smtp.gmail.com";
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = basicCredential;
                SmtpServer.Send(mail);

                return RedirectToAction("Zamowienia");
            }
            ViewBag.product_id = new SelectList(Status.statusy, "id", "name", zam.Id);
            return View(zam);
        }

    }
}
