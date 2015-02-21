using SCSD.BLL.BussinessLogic;
using SCSD.DTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCSD.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private AuthendicationBL _authendicationBL = null;
        public HomeController()
        {
            _authendicationBL = new AuthendicationBL();
        }

        [HttpGet]
        public ActionResult Dashboard()
        {
            ViewBag.Entity = "Dashboard";
            return View();
        }

        [HttpGet]
        public ActionResult Personal()
        {
            ViewBag.Entity = "Profile";
            UserDetail userDetail = new UserDetail();
            userDetail = _authendicationBL.GetUserDetailBL((User.Identity as SCSD.Web.SCSDIdentity).UserId);
            userDetail.UserGroups = _authendicationBL.GetUserTypeGroupBL();
            userDetail.UserTypes = _authendicationBL.GetUserTypeBL();
            List<string> marital = new List<string>();
            marital.Add("Single");
            marital.Add("Married");
            userDetail.Maritals = marital;
            return View(userDetail);
        }

        [HttpGet]
        public ActionResult PersonalEdit()
        {
            ViewBag.Entity = "Profile";
            UserDetail userDetail = new UserDetail();
            userDetail = _authendicationBL.GetUserDetailBL((User.Identity as SCSD.Web.SCSDIdentity).UserId);
            userDetail.UserGroups = _authendicationBL.GetUserTypeGroupBL();
            userDetail.UserTypes = _authendicationBL.GetUserTypeBL();
            List<string> marital = new List<string>();
            marital.Add("Single");
            marital.Add("Married");
            userDetail.Maritals = marital;
            return View(userDetail);
        }

        [HttpPost]
        public ActionResult PersonalEdit(UserDetail userDetail)
        {
            ViewBag.Entity = "Profile";
            userDetail.UserGroups = _authendicationBL.GetUserTypeGroupBL();
            userDetail.UserTypes = _authendicationBL.GetUserTypeBL();
            List<string> marital = new List<string>();
            marital.Add("Single");
            marital.Add("Married");
            userDetail.Maritals = marital;

            if (ModelState.IsValid)
            {
                userDetail.UserId = (User.Identity as SCSD.Web.SCSDIdentity).UserId;
                var updateResult = _authendicationBL.UpdateUserDeatilBL(userDetail);
                if (updateResult == "success")
                {
                    return RedirectToAction("Dashboard", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Failed");
                }
            }

            return View(userDetail);
        }

    }
}
