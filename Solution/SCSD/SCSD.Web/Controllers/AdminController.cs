using SCSD.BLL.BussinessLogic;
using SCSD.DTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCSD.Web.Controllers
{
    public class AdminController : Controller
    {
         private UploadDataBL _UploadDataBL;
        private AuthendicationBL _authendicationBL = null;
        public AdminController()
        {
            _UploadDataBL = new UploadDataBL();
            _authendicationBL = new AuthendicationBL();
        }

        public ActionResult UserList()
        {
            ViewBag.Entity = "UserList";
            List<UserDTO> users = new List<UserDTO>();
            users = _authendicationBL.GetUserIdentitysBL();
            return View(users);
        }

        public ActionResult FileList()
        {
            ViewBag.Entity = "FileList";
            List<UploadList> uploadList = new List<UploadList>();
            uploadList = _UploadDataBL.GetAllFileListBL();
            return View(uploadList);
        }
    }
}
