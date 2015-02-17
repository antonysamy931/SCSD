using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SCSD.DTO.Model;
using SCSD.BLL.BussinessLogic;
using System.Web.Security;

namespace SCSD.Web.Controllers
{
    public class AccountController : Controller
    {
        private AuthendicationBL _authendicationBL = null;
        public AccountController()
        {
            _authendicationBL = new AuthendicationBL();
        }

        [HttpGet]
        public ActionResult RegisterUser()
        {
            Register register = new Register();
            register.UserGroups = _authendicationBL.GetUserTypeGroupBL();
            register.UserTypes = _authendicationBL.GetUserTypeBL();
            List<string> marital = new List<string>();
            marital.Add("Single");
            marital.Add("Married");
            register.Maritals = marital;
            return View(register);
        }

        [HttpPost]
        public ActionResult RegisterUser(Register register)
        {
            if (ModelState.IsValid)
            {
                if (_authendicationBL.CheckUserNameBL(register.UserName))
                {
                    ModelState.AddModelError(string.Empty, "Username already exist");
                }
                else
                {
                    if (_authendicationBL.RegisterUserBL(register))
                    {
                        return RedirectToAction("Login", "Account");
                    }
                }
            }
            register.UserGroups = _authendicationBL.GetUserTypeGroupBL();
            register.UserTypes = _authendicationBL.GetUserTypeBL();
            List<string> marital = new List<string>();
            marital.Add("Single");
            marital.Add("Married");

            register.Maritals = marital;
            return View(register);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginUser login)
        {
            if (ModelState.IsValid)
            {
                var userId = _authendicationBL.CheckAuthenticationBL(login);
                if (string.IsNullOrEmpty(userId))
                {
                    ModelState.AddModelError(string.Empty, "Username or Password incorrect");
                    return View(login);
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(userId, false);
                    return RedirectToAction("Dashboard", "Home");
                }

            }
            return View(login);
        }

        [HttpGet]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassword(ForgotPassword forgotPassword)
        {
            if (ModelState.IsValid)
            {
                var userId = _authendicationBL.GetUserIdByUserNameBL(forgotPassword.UserName);
                if (string.IsNullOrEmpty(userId))
                {
                    ModelState.AddModelError(string.Empty, "Username invalid");
                    return View(forgotPassword);
                }
                else
                {
                    if (_authendicationBL.ChangePasswordBL(userId, forgotPassword.Password))
                    {
                        FormsAuthentication.SetAuthCookie(userId, false);
                        return RedirectToAction("Dashboard", "Home");
                    }
                }
            }
            return View(forgotPassword);
        }

        [Authorize]
        [HttpGet]
        public ActionResult Changepassword()
        {
            ViewBag.Entity = "ChangePassword";
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Changepassword(ChangePassword changePassword)
        {
            ViewBag.Entity = "ChangePassword";
            if (ModelState.IsValid)
            {
                if (_authendicationBL.ChangePasswordBL(User.Identity.Name, changePassword.NewPassword))
                {
                    return RedirectToAction("Dashboard", "Home");
                }
            }
            return View(changePassword);
        }

        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}
