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

            /*               
             * Przedostać się do synonimów i uwzględnić w wyszukiwaniu.
             */

            return View(lista);
        }

        public ActionResult Kosmetyki()
        {
            ViewBag.Message = "Kosmetyki";

            var produkty = db.t_produkty.Include(a => a.t_leki).Include(b => b.t_sklepy).Where(c => c.t_leki.t_informacje.kosmetyk_bool == true);

            return View(produkty.ToList());
        }

        public ActionResult Dieta()
        {
            ViewBag.Message = "Dieta";

            var produkty = db.t_produkty.Include(a => a.t_leki).Include(b => b.t_sklepy).Where(c => c.t_leki.t_informacje.diet_bool == true);

            return View(produkty.ToList());
        }

        public ActionResult About()
        {
            return View();
        }        
    }
}
