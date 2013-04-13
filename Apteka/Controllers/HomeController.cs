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
    public class HomeController : Controller
    {
        private db_lekiContext db = new db_lekiContext();

        public ActionResult Index(string searchString)
        {
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

            return View(lista);
        }

        public ActionResult Kosmetyki(string searchString)
        {
            ViewBag.Message = "Kosmetyki";

            var produkty = db.t_produkty.Include(a => a.t_leki).Include(b => b.t_sklepy).Where(c => c.t_leki.t_informacje.kosmetyk_bool == true);

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

            return View(lista);
        }

        public ActionResult Dieta(string searchString)
        {
            ViewBag.Message = "Dieta";

            var produkty = db.t_produkty.Include(a => a.t_leki).Include(b => b.t_sklepy).Where(c => c.t_leki.t_informacje.diet_bool == true);

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

            return View(lista);
        }

        public ActionResult Producent(string searchString)
        {
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

            return View(lista);
        }

        public ActionResult Internaz(string searchString)
        {
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

            return View(lista);
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
