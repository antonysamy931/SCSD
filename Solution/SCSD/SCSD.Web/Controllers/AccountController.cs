using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SCSD.DTO.Model;
using SCSD.BLL.BussinessLogic;

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
                return RedirectToAction("Login", "Account");
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
                return View(login);
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
                return RedirectToAction("Login", "Account");
            }
            return View(forgotPassword);
        }
    }
}
