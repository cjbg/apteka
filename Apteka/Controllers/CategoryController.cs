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

        public ActionResult Index(string searchString, IEnumerable<Apteka.t_produkty> sortModel)
        {
            ViewBag.Message = "Wszystkie leki";
            ViewBag.ActionName = "Index";

            if (sortModel == null)
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
            else
            {
                return View(sortModel);
            }
        }

        public ActionResult Kosmetyki(string searchString, IEnumerable<Apteka.t_produkty> sortModel)
        {
            ViewBag.Message = "Kosmetyki";
            ViewBag.ActionName = "Kosmetyki";

            if (sortModel == null)
            {
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

                return View("index", lista);
            }
            else
            {
                return View("index", sortModel);
            }
        }

        public ActionResult Dieta(string searchString, IEnumerable<Apteka.t_produkty> sortModel)
        {
            ViewBag.Message = "Dieta";
            ViewBag.ActionName = "Dieta";

            if (sortModel == null)
            {
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

                return View("index", lista);
            }
            else
            {
                return View("index", sortModel);
            }
        }

        public ActionResult Dezynfekcyjny(string searchString, IEnumerable<Apteka.t_produkty> sortModel)
        {
            ViewBag.Message = "Dezynfekcyjny";
            ViewBag.ActionName = "Dezynfekcyjny";

            if (sortModel == null)
            {
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

                return View("index", lista);
            }
            else
            {
                return View("index", sortModel);
            }
        }

        public ActionResult Homeopatyczny(string searchString, IEnumerable<Apteka.t_produkty> sortModel)
        {
            ViewBag.Message = "Homeopatyczny";
            ViewBag.ActionName = "Homeopatyczny";

            if (sortModel == null)
            {
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

                return View("index", lista);
            }
            else
            {
                return View("index", sortModel);
            }
        }

        public ActionResult Doping(string searchString, IEnumerable<Apteka.t_produkty> sortModel)
        {
            ViewBag.Message = "Środek dopingujący";
            ViewBag.ActionName = "Doping";

            if (sortModel == null)
            {
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

                return View("index", lista);
            }
            else
            {
                return View("index", sortModel);
            }
        }

        public ActionResult Producent(string searchString, IEnumerable<Apteka.t_produkty> sortModel)
        {
            ViewBag.Message = "Producent";
            ViewBag.ActionName = "Producent";

            if (sortModel == null)
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

                return View("index", lista);
            }
            else
            {
                return View("index", sortModel);
            }
        }

        public ActionResult Internaz(string searchString, IEnumerable<Apteka.t_produkty> sortModel)
        {
            ViewBag.Message = "Nazwa międzynarodowa";
            ViewBag.ActionName = "Internaz";

            if (sortModel == null)
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

                return View("index", lista);
            }
            else
            {
                return View("index", sortModel);
            }
        }

        public ActionResult Apteka(string searchString, IEnumerable<Apteka.t_produkty> sortModel)
        {
            ViewBag.Message = "Oferta aptek";
            ViewBag.ActionName = "Apteka";

            if (sortModel == null)
            {
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

                return View("index", lista);
            }
            else
            {
                return View("index", sortModel);
            }
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
