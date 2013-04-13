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
    public class SortController : Controller
    {
        private db_lekiContext db = new db_lekiContext();
        
        //
        // GET: /Sort/

        //Wszystkie

        public ActionResult Index(string searchString) // Sortowanie wg ceny
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

            lista.OrderBy(a => a.cena);

            return View(lista);
        }

        public ActionResult IndexI(string searchString) // Sortowanie wg ceny
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

            lista.OrderBy(a => a.ilosc);

            return View(lista);
        }

        public ActionResult IndexCI(string searchString) // Sortowanie wg ceny
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

            lista.OrderBy(a => a.cena).OrderBy(a => a.ilosc);

            return View(lista);
        }

        // Kosmetyki

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

            lista.OrderBy(a => a.cena);

            return View(lista);
        }

        public ActionResult KosmetykiI(string searchString)
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

            lista.OrderBy(a => a.ilosc);

            return View(lista);
        }

        public ActionResult KosmetykiCI(string searchString)
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

            lista.OrderBy(a => a.cena).OrderBy(a => a.ilosc);

            return View(lista);
        }

        // Dieta

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

            lista.OrderBy(a => a.cena);

            return View(lista);
        }

        public ActionResult DietaI(string searchString)
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

            lista.OrderBy(a => a.ilosc);

            return View(lista);
        }

        public ActionResult DietaCI(string searchString)
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

            lista.OrderBy(a => a.cena).OrderBy(a => a.ilosc);

            return View(lista);
        }

        // Po producencie

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

            lista.OrderBy(a => a.cena);

            return View(lista);
        }

        public ActionResult ProducentI(string searchString)
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

            lista.OrderBy(a => a.ilosc);

            return View(lista);
        }

        public ActionResult ProducentCI(string searchString)
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

            lista.OrderBy(a => a.cena).OrderBy(a => a.ilosc);

            return View(lista);
        }

        // Po nazwie międzynarodowej

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

            lista.OrderBy(a => a.cena);

            return View(lista);
        }

        public ActionResult InternazI(string searchString)
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

            lista.OrderBy(a => a.ilosc);

            return View(lista);
        }

        public ActionResult InternazCI(string searchString)
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

            lista.OrderBy(a => a.cena).OrderBy(a => a.ilosc);

            return View(lista);
        }
    }
}
