using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Apteka;

namespace Apteka.Controllers
{ 
    public class ProduktyController : Controller
    {
        private db_lekiContext db = new db_lekiContext();

        //
        // GET: /Produkty/

        public ViewResult Index()
        {
            var t_produkty = db.t_produkty.Include(t => t.t_sklepy).Include(t => t.t_leki).Where(a => a.t_sklepy.t_users.Login == User.Identity.Name);
            return View(t_produkty.ToList());
        }

        //
        // GET: /Produkty/Details/5

        public ViewResult Details(int id)
        {
            t_produkty t_produkty = db.t_produkty.Find(id);
            return View(t_produkty);
        }

        //
        // GET: /Produkty/Create

        public ActionResult Create()
        {            
            ViewBag.lek_id = new SelectList(db.t_leki.Where(c => c.t_informacje.bez_rec_bool == true), "pk_lek_id_num", "nazwa_char");
            return View();
            // <script src="@Url.Content("~/Scripts/jquery.validate.min.js")" type="text/javascript"></script>
        } 

        //
        // POST: /Produkty/Create

        [HttpPost]
        public ActionResult Create(t_produkty t_produkty)
        {
            var asd = db.t_sklepy.Where(b => b.t_users.Login == User.Identity.Name);

            if (ModelState.IsValid)
            {
                t_produkty.sklep_id = asd.First().Id;
                db.t_produkty.Add(t_produkty);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }
            ViewBag.lek_id = new SelectList(db.t_leki.Where(c => c.t_informacje.bez_rec_bool == true), "pk_lek_id_num", "nazwa_char", t_produkty.lek_id);
            return View(t_produkty);
        }
        
        //
        // GET: /Produkty/Edit/5
 
        public ActionResult Edit(int id)
        {
            t_produkty t_produkty = db.t_produkty.Find(id);
            ViewBag.lek_id = new SelectList(db.t_leki.Where(c => c.t_informacje.bez_rec_bool == true), "pk_lek_id_num", "nazwa_char", t_produkty.lek_id);
            return View(t_produkty);
        }

        //
        // POST: /Produkty/Edit/5

        [HttpPost]
        public ActionResult Edit(t_produkty t_produkty)
        {
            var asd = db.t_sklepy.Where(b => b.t_users.Login == User.Identity.Name);

            if (ModelState.IsValid)
            {
                t_produkty.sklep_id = asd.First().Id;
                db.Entry(t_produkty).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.lek_id = new SelectList(db.t_leki.Where(c => c.t_informacje.bez_rec_bool == true), "pk_lek_id_num", "nazwa_char", t_produkty.lek_id);
            return View(t_produkty);
        }

        //
        // GET: /Produkty/Delete/5
 
        public ActionResult Delete(int id)
        {
            t_produkty t_produkty = db.t_produkty.Find(id);
            return View(t_produkty);
        }

        //
        // POST: /Produkty/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            t_produkty t_produkty = db.t_produkty.Find(id);
            db.t_produkty.Remove(t_produkty);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}