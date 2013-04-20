using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Apteka.Models;
using System.Data;
using System.Data.Entity;
using System.Net.Mail;
using System.Net;

namespace Apteka.Controllers
{
    public class AccountController : Controller
    {

        //
        // GET: /Account/LogOn

        private db_lekiContext db = new db_lekiContext();

        public ActionResult LogOn()
        {
            return View();
        }

        //
        // POST: /Account/LogOn

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {            
            if (ModelState.IsValid)
            {
                var data = db.t_users.Where(a => a.Login == model.UserName && a.Haslo == model.Password);

                if (data.Count() > 0)
                {
                    if (data.First().IsValid.Equals("1"))
                    {
                        // dodać czas życia ciasteczka
                        if (data.First().Admin == true)
                        {
                            Session["Admin"] = "Admin";
                            // Response.Cookies.Add(new HttpCookie("Admin","1"));
                        }
                        else
                        {
                            Session["Admin"] = "";
                            // Response.Cookies.Add(new HttpCookie("Admin", "0"));
                        }

                        if (Membership.ValidateUser(model.UserName, model.Password))
                        {
                            FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                            if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                                && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                            {
                                return Redirect(returnUrl);
                            }
                            else
                            {
                                return RedirectToAction("Index", "Home");
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("", "The user name or password provided is incorrect.");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "The user name or password provided is incorrect.");
                    }
                }
            }
            ModelState.AddModelError("", "Proszę potwierdzić rejestrację");
            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/LogOff

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/Register

        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register

        [HttpPost]
        public ActionResult Register(t_users model)
        {
            int id = 0;
            var usr = db.t_users;

            foreach (var a in usr)
            {
                id = a.Id;
            }

            model.Id = id++;
            model.Admin = false;

           

            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnoprstquywz";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, 14)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());


            model.IsValid = result;
            //email

            MailMessage mail = new MailMessage();
            NetworkCredential basicCredential =
            new NetworkCredential("aptegropl", "1q2w3e4r%T"); 
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("aptegropl@gmail.com");           
            mail.To.Add(model.email);
            mail.Subject = "Registration confirmation";
            mail.IsBodyHtml = true;
            mail.Body = "Confirmation <br/> <a href=\"http://localhost:56533/Account/RegisterConfirmation?searchString="+ result+"\">Confirm registration by clicking this link</a> ";

            SmtpServer.Host = "smtp.gmail.com";
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Credentials = basicCredential;
            SmtpServer.Send(mail);

            db.t_users.Add(model);
            db.SaveChanges();


            return RedirectToAction("Index", "Home");
        }

        public ActionResult RegisterConfirmation(string searchString)
        {
            var asd = db.t_users.Where(a => a.IsValid == searchString);

            if (asd.Count() > 0)
            {
                // Attempt to register the user
                MembershipCreateStatus createStatus;
                Membership.CreateUser(asd.First().Login, asd.First().Haslo, asd.First().email, null, null, true, null, out createStatus);

                if (asd.First().Admin)
                {

                    Session["Admin"] = "";
                }
                else
                {
                    Session["Admin"] = "Admin";
                }

                asd.First().IsValid = "1";
                                              

                if (createStatus == MembershipCreateStatus.Success)
                {
                    FormsAuthentication.SetAuthCookie(asd.First().Login, false /* createPersistentCookie */);
                    db.Entry(asd.First()).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", ErrorCodeToString(createStatus));
                }
            }
                return View();
            
        }

        public ActionResult ShopRegister()
        {
            return View();
        }

        //
        // POST: /Account/Register

        [HttpPost]
        public ActionResult ShopRegister(t_sklepy model)
        {
            if (ModelState.IsValid)
            {
                int id = 0;
                var usr = db.t_users;

                foreach (var a in usr)
                {
                    id = a.Id;
                }

                model.t_users.Id = id++;

                var skl = db.t_sklepy;

                foreach (var a in skl)
                {
                    id = a.Id;
                }

                model.Id = id++;

                model.t_users.Admin = true;

                var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnoprstquywz";
                var random = new Random();
                var result = new string(
                    Enumerable.Repeat(chars, 14)
                              .Select(s => s[random.Next(s.Length)])
                              .ToArray());


                model.t_users.IsValid = result;
                //email

                MailMessage mail = new MailMessage();
                NetworkCredential basicCredential =
                new NetworkCredential("aptegropl", "1q2w3e4r%T");
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("aptegropl@gmail.com");
                mail.To.Add(model.t_users.email);
                mail.Subject = "Registration confirmation";
                mail.IsBodyHtml = true;
                mail.Body = "Confirmation <br/> <a href=\"http://localhost:56533/Account/RegisterConfirmation?searchString=" + result + "\">Confirm registration by clicking this link</a> ";

                SmtpServer.Host = "smtp.gmail.com";
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = basicCredential;
                SmtpServer.Send(mail);

                db.t_users.Add(model.t_users);
                db.t_sklepy.Add(model);
                db.SaveChanges();

            }
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/ChangePassword

        [Authorize]
        public ActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Account/ChangePassword

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {

                // ChangePassword will throw an exception rather
                // than return false in certain failure scenarios.
                bool changePasswordSucceeded;
                try
                {
                    MembershipUser currentUser = Membership.GetUser(User.Identity.Name, true /* userIsOnline */);
                    changePasswordSucceeded = currentUser.ChangePassword(model.OldPassword, model.NewPassword);
                }
                catch (Exception)
                {
                    changePasswordSucceeded = false;
                }

                if (changePasswordSucceeded)
                {
                    return RedirectToAction("ChangePasswordSuccess");
                }
                else
                {
                    ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ChangePasswordSuccess

        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }

        #region Status Codes
        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
        #endregion
    }
}
