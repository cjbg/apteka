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

        public ActionResult Index()
        {
            return View();
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
