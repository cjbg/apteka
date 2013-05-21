using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Apteka;
using Apteka.Controllers;
using Apteka.Models;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Routing;
using System.Web.Security;
using Apteka.Common;


namespace Apteka.Controllers
{
    public class CategoryController : Controller
    {
        private db_lekiContext db = new db_lekiContext();

        public ActionResult Index(string searchString, string sortModel)
        {
            ViewBag.Message = "Wszystkie leki";
            ViewBag.ActionName = "Index";
            ViewBag.Category = "Nazwa";

            var produkty = db.t_produkty.Include(a => a.t_leki).Include(b => b.t_sklepy).Where(c => c.t_leki.t_informacje.bez_rec_bool == true);

            var synonimy = produkty;

            List<t_produkty> lista = new List<t_produkty>();

            if (!String.IsNullOrEmpty(searchString))
            {
                produkty = produkty.Where(a => a.t_leki.nazwa_char.Contains(searchString));
                synonimy = synonimy.Where(b => b.t_leki.t_informacje.t_syno.nazwa_char.Equals(searchString));

                foreach (var p in synonimy)
                {
                    lista.Add(p);
                }
                foreach (var p in produkty)
                {
                    lista.Add(p);
                }
            }
            else
            {
                lista = produkty.ToList();
            }

            switch (sortModel)
            {
                case "cena": lista = lista.OrderBy(x => x.cena).ToList();
                    break;
                case "ilosc": lista = lista.OrderBy(x => x.ilosc).ToList();
                    break;
                case "cenailosc": lista = lista.OrderBy(x => x.cena).ThenBy(x=>x.ilosc).ToList();
                    break;                                
                case "sklep": lista = lista.OrderBy(x => x.t_sklepy.Nazwa).ToList();
                    break;
                case "producent": lista = lista.OrderBy(x => x.t_leki.t_producenci.nazwa_char).ToList();
                    break;
                case "internaz": lista = lista.OrderBy(x => x.t_leki.t_informacje.t_inter.nazwa_char).ToList();
                    break;
                case "nazwa": lista = lista.OrderBy(x => x.t_leki.nazwa_char).ToList();
                    break;
            }

            return View(lista);
        }

        public ActionResult Kosmetyki(string searchString, string sortModel)
        {
            ViewBag.Message = "Kosmetyki";
            ViewBag.ActionName = "Kosmetyki";
            ViewBag.Category = "Nazwa";
            
            var produkty = db.t_produkty.Include(a => a.t_leki).Include(b => b.t_sklepy).Where(c => c.t_leki.t_informacje.kosmetyk_bool == true && c.t_leki.t_informacje.bez_rec_bool == true);

            var synonimy = produkty;

            List<t_produkty> lista = new List<t_produkty>();

            if (!String.IsNullOrEmpty(searchString))
            {
                produkty = produkty.Where(a => a.t_leki.nazwa_char.Contains(searchString));
                synonimy = synonimy.Where(b => b.t_leki.t_informacje.t_syno.nazwa_char.Equals(searchString));

                foreach (var p in synonimy)
                {
                    lista.Add(p);
                }
                foreach (var p in produkty)
                {
                    lista.Add(p);
                }
            }
            else
            {
                lista = produkty.ToList();
            }

            switch (sortModel)
            {
                case "cena": lista = lista.OrderBy(x => x.cena).ToList();
                    break;
                case "ilosc": lista = lista.OrderBy(x => x.ilosc).ToList();
                    break;
                case "cenailosc": lista = lista.OrderBy(x => x.cena).ThenBy(x => x.ilosc).ToList();
                    break;
            }

            return View("index", lista);
        }

        public ActionResult Dieta(string searchString, string sortModel)
        {
            ViewBag.Message = "Dieta";
            ViewBag.ActionName = "Dieta";
            ViewBag.Category = "Nazwa";

            var produkty = db.t_produkty.Include(a => a.t_leki).Include(b => b.t_sklepy).Where(c => c.t_leki.t_informacje.diet_bool == true && c.t_leki.t_informacje.bez_rec_bool == true);

            var synonimy = produkty;

            List<t_produkty> lista = new List<t_produkty>();

            if (!String.IsNullOrEmpty(searchString))
            {
                produkty = produkty.Where(a => a.t_leki.nazwa_char.Contains(searchString));
                synonimy = synonimy.Where(b => b.t_leki.t_informacje.t_syno.nazwa_char.Equals(searchString));

                foreach (var p in synonimy)
                {
                    lista.Add(p);
                }
                foreach (var p in produkty)
                {
                    lista.Add(p);
                }
            }
            else
            {
                lista = produkty.ToList();
            }

            switch (sortModel)
            {
                case "cena": lista = lista.OrderBy(x => x.cena).ToList();
                    break;
                case "ilosc": lista = lista.OrderBy(x => x.ilosc).ToList();
                    break;
                case "cenailosc": lista = lista.OrderBy(x => x.cena).ThenBy(x => x.ilosc).ToList();
                    break;
                case "sklep": lista = lista.OrderBy(x => x.t_sklepy.Nazwa).ToList();
                    break;
                case "producent": lista = lista.OrderBy(x => x.t_leki.t_producenci.nazwa_char).ToList();
                    break;
                case "internaz": lista = lista.OrderBy(x => x.t_leki.t_informacje.t_inter.nazwa_char).ToList();
                    break;
                case "nazwa": lista = lista.OrderBy(x => x.t_leki.nazwa_char).ToList();
                    break;
            }

            return View("index", lista);
        }

        public ActionResult Dezynfekcyjny(string searchString, string sortModel)
        {
            ViewBag.Message = "Dezynfekcyjny";
            ViewBag.ActionName = "Dezynfekcyjny";
            ViewBag.Category = "Nazwa";

            var produkty = db.t_produkty.Include(a => a.t_leki).Include(b => b.t_sklepy).Where(c => c.t_leki.t_informacje.dezyn_bool == true && c.t_leki.t_informacje.bez_rec_bool == true);

            var synonimy = produkty;

            List<t_produkty> lista = new List<t_produkty>();

            if (!String.IsNullOrEmpty(searchString))
            {
                produkty = produkty.Where(a => a.t_leki.nazwa_char.Contains(searchString));
                synonimy = synonimy.Where(b => b.t_leki.t_informacje.t_syno.nazwa_char.Equals(searchString));

                foreach (var p in synonimy)
                {
                    lista.Add(p);
                }
                foreach (var p in produkty)
                {
                    lista.Add(p);
                }
            }
            else
            {
                lista = produkty.ToList();
            }

            switch (sortModel)
            {
                case "cena": lista = lista.OrderBy(x => x.cena).ToList();
                    break;
                case "ilosc": lista = lista.OrderBy(x => x.ilosc).ToList();
                    break;
                case "cenailosc": lista = lista.OrderBy(x => x.cena).ThenBy(x => x.ilosc).ToList();
                    break;
                case "sklep": lista = lista.OrderBy(x => x.t_sklepy.Nazwa).ToList();
                    break;
                case "producent": lista = lista.OrderBy(x => x.t_leki.t_producenci.nazwa_char).ToList();
                    break;
                case "internaz": lista = lista.OrderBy(x => x.t_leki.t_informacje.t_inter.nazwa_char).ToList();
                    break;
                case "nazwa": lista = lista.OrderBy(x => x.t_leki.nazwa_char).ToList();
                    break;
            }

            return View("index", lista);
        }

        public ActionResult Homeopatyczny(string searchString, string sortModel)
        {
            ViewBag.Message = "Homeopatyczny";
            ViewBag.ActionName = "Homeopatyczny";
            ViewBag.Category = "Nazwa";

            var produkty = db.t_produkty.Include(a => a.t_leki).Include(b => b.t_sklepy).Where(c => c.t_leki.t_informacje.homeo_bool == true && c.t_leki.t_informacje.bez_rec_bool == true);

            var synonimy = produkty;

            List<t_produkty> lista = new List<t_produkty>();

            if (!String.IsNullOrEmpty(searchString))
            {
                produkty = produkty.Where(a => a.t_leki.nazwa_char.Contains(searchString));
                synonimy = synonimy.Where(b => b.t_leki.t_informacje.t_syno.nazwa_char.Equals(searchString));

                foreach (var p in synonimy)
                {
                    lista.Add(p);
                }
                foreach (var p in produkty)
                {
                    lista.Add(p);
                }
            }
            else
            {
                lista = produkty.ToList();
            }

            switch (sortModel)
            {
                case "cena": lista = lista.OrderBy(x => x.cena).ToList();
                    break;
                case "ilosc": lista = lista.OrderBy(x => x.ilosc).ToList();
                    break;
                case "cenailosc": lista = lista.OrderBy(x => x.cena).ThenBy(x => x.ilosc).ToList();
                    break;
                case "sklep": lista = lista.OrderBy(x => x.t_sklepy.Nazwa).ToList();
                    break;
                case "producent": lista = lista.OrderBy(x => x.t_leki.t_producenci.nazwa_char).ToList();
                    break;
                case "internaz": lista = lista.OrderBy(x => x.t_leki.t_informacje.t_inter.nazwa_char).ToList();
                    break;
                case "nazwa": lista = lista.OrderBy(x => x.t_leki.nazwa_char).ToList();
                    break;
            }

            return View("index", lista);
        }

        public ActionResult Doping(string searchString, string sortModel)
        {
            ViewBag.Message = "Środek dopingujący";
            ViewBag.ActionName = "Doping";
            ViewBag.Category = "Nazwa";

            var produkty = db.t_produkty.Include(a => a.t_leki).Include(b => b.t_sklepy).Where(c => c.t_leki.t_informacje.doping_bool == true && c.t_leki.t_informacje.bez_rec_bool == true);

            var synonimy = produkty;

            List<t_produkty> lista = new List<t_produkty>();

            if (!String.IsNullOrEmpty(searchString))
            {
                produkty = produkty.Where(a => a.t_leki.nazwa_char.Contains(searchString));
                synonimy = synonimy.Where(b => b.t_leki.t_informacje.t_syno.nazwa_char.Equals(searchString));

                foreach (var p in synonimy)
                {
                    lista.Add(p);
                }
                foreach (var p in produkty)
                {
                    lista.Add(p);
                }
            }
            else
            {
                lista = produkty.ToList();
            }

            switch (sortModel)
            {
                case "cena": lista = lista.OrderBy(x => x.cena).ToList();
                    break;
                case "ilosc": lista = lista.OrderBy(x => x.ilosc).ToList();
                    break;
                case "cenailosc": lista = lista.OrderBy(x => x.cena).ThenBy(x => x.ilosc).ToList();
                    break;
                case "sklep": lista = lista.OrderBy(x => x.t_sklepy.Nazwa).ToList();
                    break;
                case "producent": lista = lista.OrderBy(x => x.t_leki.t_producenci.nazwa_char).ToList();
                    break;
                case "internaz": lista = lista.OrderBy(x => x.t_leki.t_informacje.t_inter.nazwa_char).ToList();
                    break;
                case "nazwa": lista = lista.OrderBy(x => x.t_leki.nazwa_char).ToList();
                    break;
            }

            return View("index", lista);
        }

        public ActionResult Producent(string searchString, string sortModel)
        {
            ViewBag.Message = "Producent";
            ViewBag.ActionName = "Producent";
            ViewBag.Category = "Producent";

            var produkty = db.t_produkty.Include(a => a.t_leki).Include(b => b.t_sklepy).Where(c => c.t_leki.t_informacje.bez_rec_bool == true);

            List<t_produkty> lista = new List<t_produkty>();

            if (!String.IsNullOrEmpty(searchString))
            {
                produkty = produkty.Where(a => a.t_leki.t_producenci.nazwa_char.Contains(searchString));
                foreach (var p in produkty)
                {
                    lista.Add(p);
                }
            }
            else
            {
                lista = produkty.ToList();
            }

            switch (sortModel)
            {
                case "cena": lista = lista.OrderBy(x => x.cena).ToList();
                    break;
                case "ilosc": lista = lista.OrderBy(x => x.ilosc).ToList();
                    break;
                case "cenailosc": lista = lista.OrderBy(x => x.cena).ThenBy(x => x.ilosc).ToList();
                    break;
                case "sklep": lista = lista.OrderBy(x => x.t_sklepy.Nazwa).ToList();
                    break;
                case "producent": lista = lista.OrderBy(x => x.t_leki.t_producenci.nazwa_char).ToList();
                    break;
                case "internaz": lista = lista.OrderBy(x => x.t_leki.t_informacje.t_inter.nazwa_char).ToList();
                    break;
                case "nazwa": lista = lista.OrderBy(x => x.t_leki.nazwa_char).ToList();
                    break;
            }

            return View("index", lista);
        }

        public ActionResult Internaz(string searchString, string sortModel)
        {
            ViewBag.Message = "Nazwa międzynarodowa";
            ViewBag.ActionName = "Internaz";
            ViewBag.Category = "Nazwa międzynarodowa";

            var produkty = db.t_produkty.Include(a => a.t_leki).Include(b => b.t_sklepy).Where(c => c.t_leki.t_informacje.bez_rec_bool == true);

            List<t_produkty> lista = new List<t_produkty>();

            if (!String.IsNullOrEmpty(searchString))
            {
                produkty = produkty.Where(a => a.t_leki.t_informacje.t_inter.nazwa_char.Contains(searchString));
                foreach (var p in produkty)
                {
                    lista.Add(p);
                }
            }
            else
            {
                lista = produkty.ToList();
            }

            switch (sortModel)
            {
                case "cena": lista = lista.OrderBy(x => x.cena).ToList();
                    break;
                case "ilosc": lista = lista.OrderBy(x => x.ilosc).ToList();
                    break;
                case "cenailosc": lista = lista.OrderBy(x => x.cena).ThenBy(x => x.ilosc).ToList();
                    break;
                case "sklep": lista = lista.OrderBy(x => x.t_sklepy.Nazwa).ToList();
                    break;
                case "producent": lista = lista.OrderBy(x => x.t_leki.t_producenci.nazwa_char).ToList();
                    break;                
                case "nazwa": lista = lista.OrderBy(x => x.t_leki.nazwa_char).ToList();
                    break;
            }

            return View("index", lista);
        }

        public ActionResult Apteka(string searchString, string sortModel)
        {
            ViewBag.Message = "Oferta aptek";
            ViewBag.ActionName = "Apteka";
            ViewBag.Category = "Oferta aptek";

            var produkty = db.t_produkty.Include(a => a.t_leki).Include(b => b.t_sklepy).Where(c => c.t_leki.t_informacje.bez_rec_bool == true);

            List<t_produkty> lista = new List<t_produkty>();

            if (!String.IsNullOrEmpty(searchString))
            {
                produkty = produkty.Where(a => a.t_sklepy.Nazwa.Contains(searchString));
                foreach (var p in produkty)
                {
                    lista.Add(p);
                }
            }
            else
            {
                lista = produkty.ToList();
            }

            switch (sortModel)
            {
                case "cena": lista = lista.OrderBy(x => x.cena).ToList();
                    break;
                case "ilosc": lista = lista.OrderBy(x => x.ilosc).ToList();
                    break;
                case "cenailosc": lista = lista.OrderBy(x => x.cena).ThenBy(x => x.ilosc).ToList();
                    break;
                case "sklep": lista = lista.OrderBy(x => x.t_sklepy.Nazwa).ToList();
                    break;
                case "producent": lista = lista.OrderBy(x => x.t_leki.t_producenci.nazwa_char).ToList();
                    break;
                case "internaz": lista = lista.OrderBy(x => x.t_leki.t_informacje.t_inter.nazwa_char).ToList();
                    break;
                case "nazwa": lista = lista.OrderBy(x => x.t_leki.nazwa_char).ToList();
                    break;
            }

            return View("index", lista);
        }

        public ActionResult About()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult SimpleVerticalMenu()
        {
            //The menu datasource. 
            var items = MenuItems.Get();

            string action = ControllerContext.ParentActionViewContext.RouteData.Values["action"].ToString();
            string controller = ControllerContext.ParentActionViewContext.RouteData.Values["controller"].ToString();

            items.ForEach(i => i.MenuItems.ForEach(m =>
            {
                if (m.Controller.ToLower().Equals(controller.ToLower()) && m.Action.ToLower().Equals(action.ToLower()))
                {
                    m.Selected = i.Active = true;
                }
            }));

            return PartialView(items);
        }
    }
}
