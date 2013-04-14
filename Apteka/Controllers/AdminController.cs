using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Apteka.Common;

namespace Apteka.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        private db_lekiContext db = new db_lekiContext();

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
                var s = Status.getDurationListDD;
                var a = ViewData["changeduration"];
                db.Entry(zam).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Zamowienia");
            }
            ViewBag.product_id = new SelectList(Status.statusy, "id", "name", zam.Id);
            return View(zam);
        }

    }
}
