using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Apteka.Controllers
{
    public class CheckoutController : Controller
    {
        //
        // GET: /Checkout/

        public ActionResult AddressAndPayment()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return RedirectToAction("LogOn", "Account");
            }
        }

    }
}
