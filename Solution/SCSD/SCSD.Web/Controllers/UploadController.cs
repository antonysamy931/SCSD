using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SCSD.DTO.Model;
using System.IO;
using SCSD.BLL.BussinessLogic;
using System.Net.Mail;
using System.Net;
using System.Net.Configuration;
using System.Configuration;

namespace SCSD.Web.Controllers
{
    [Authorize]
    public class UploadController : Controller
    {
        private UploadDataBL _UploadDataBL;
        private AuthendicationBL _authendicationBL = null;
        public UploadController()
        {
            _UploadDataBL = new UploadDataBL();
            _authendicationBL = new AuthendicationBL();
        }

        //
        // GET: /Upload/
        [HttpGet]
        public ActionResult UserUpload()
        {
            ViewBag.Entity = "UploadFile";
            return View();
        }

        [HttpPost]
        public ActionResult UserUpload(HttpPostedFileBase Baner, HttpPostedFileBase FileContent)
        {
            ViewBag.Entity = "UploadFile";
            UploadFile uploadFile = new UploadFile();
            uploadFile.Description = Request.Form["Description"] == null ? string.Empty : Request.Form["Description"].ToString();
            if (Baner != null)
            {
                if (Baner.ContentLength != 0)
                {
                    if (Path.GetExtension(Baner.FileName).ToLower() != ".jpg"
                       && Path.GetExtension(Baner.FileName).ToLower() != ".png"
                       && Path.GetExtension(Baner.FileName).ToLower() != ".gif"
                       && Path.GetExtension(Baner.FileName).ToLower() != ".jpeg")
                    {
                        ModelState.AddModelError(string.Empty, "File cover must be image format");
                        return View(uploadFile);
                    }
                    uploadFile.Baner = CheckSumGenerator.GetByteFromStream(Baner.InputStream, Baner.ContentLength);
                    uploadFile.BanerApplicationType = Baner.ContentType;
                }
            }

            if (FileContent != null)
            {
                if (FileContent.ContentLength != 0)
                {
                    if (Path.GetExtension(FileContent.FileName).ToLower() != ".exe")
                    {
                        byte[] key1;
                        byte[] key2;
                        EllipticAsymmetric.KeyGenerator(out key1, out key2);
                        uploadFile.AsymKey = key2;
                        uploadFile.Type = EllipticAsymmetric.Encrypte(key1, Path.GetExtension(FileContent.FileName).ToLower());
                        uploadFile.Name = EllipticAsymmetric.Encrypte(key1, Path.GetFileNameWithoutExtension(FileContent.FileName).ToLower());
                        uploadFile.ApplicaitonType = EllipticAsymmetric.Encrypte(key1, FileContent.ContentType);

                        uploadFile.SymmeticKey = Guid.NewGuid().ToString();
                        byte[] fileData;
                        uploadFile.FileCheckSum = CheckSumGenerator.GetCheckSum(FileContent.InputStream, FileContent.ContentLength, out fileData);

                        if (_UploadDataBL.CheckImageExistBL(uploadFile.FileCheckSum, (User.Identity as SCSD.Web.SCSDIdentity).UserId))
                        {
                            ModelState.AddModelError(string.Empty, "File already exist for your account");
                            return View(uploadFile);
                        }
                        else
                        {
                            uploadFile.FileContent = SymmetricEncryption.Encrypt(fileData, uploadFile.SymmeticKey);
                            uploadFile.FileId = Guid.NewGuid().ToString();
                            uploadFile.UserId = (User.Identity as SCSD.Web.SCSDIdentity).UserId;
                            if (_UploadDataBL.InsertFileBL(uploadFile))
                            {
                                return RedirectToAction("UploadList", "Upload");
                            }
                        }
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "File format not suported.");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "File must be upload");
                    return View(uploadFile);
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "File must be upload");
                return View(uploadFile);
            }
            return View(uploadFile);
        }

        public ActionResult DeleteFile(string FileId)
        {
            _UploadDataBL.DeleteFileBL(FileId);
            if (User.Identity.Name == "Admin")
            {
                return RedirectToAction("FileList", "Admin");
            }
            else
            {
                return RedirectToAction("UploadList", "Upload");
            }             
        }

        [HttpGet]
        public ActionResult UploadList()
        {
            ViewBag.Entity = "UploadList";
            List<UploadList> uploadList = new List<UploadList>();
            uploadList = _UploadDataBL.GetUploadFileListBL((User.Identity as SCSD.Web.SCSDIdentity).UserId);
            return View(uploadList);
        }

        [HttpGet]
        public ActionResult GetBanar(string BanarId)
        {
            var banardata = _UploadDataBL.BanarDataBL(BanarId);
            return File(banardata, "image/jpeg");
        }

        [HttpGet]
        public ActionResult GetDocument(string FileId)
        {
            var document = _UploadDataBL.GetDocumentBL(FileId);
            if (document.ContentType == "application/zip")
            {
                document.ContentType = "application/x-zip-compressed";
            }
            return File(document.File, document.ContentType, document.FileName);
        }

        [HttpGet]
        public ActionResult ShareDocument(string FileId)
        {
            ViewBag.Entity = "UploadFile";
            ShareFile file = new ShareFile();
            file.FileId = FileId;
            file.uploadFile = _UploadDataBL.GetUploadFileBL((User.Identity as SCSD.Web.SCSDIdentity).UserId, FileId);
            file.UserList = _authendicationBL.UserListBL((User.Identity as SCSD.Web.SCSDIdentity).UserId, FileId);
            return View(file);
        }

        [HttpPost]
        public ActionResult ShareDocument(ShareFile file)
        {
            var userList = Request.Form["Users"];
            if (userList != null)
            {
                var users = userList.Split(',');
                _UploadDataBL.ShareUserBL((User.Identity as SCSD.Web.SCSDIdentity).UserId, users, file.FileId);
                return RedirectToAction("UploadList", "Upload");
            }
            file.uploadFile = _UploadDataBL.GetUploadFileBL((User.Identity as SCSD.Web.SCSDIdentity).UserId, file.FileId);
            file.UserList = _authendicationBL.UserListBL((User.Identity as SCSD.Web.SCSDIdentity).UserId, file.FileId);
            return View(file);
        }

        [HttpGet]
        public ActionResult ReceivedList()
        {
            ViewBag.Entity = "ReceivedList";
            List<UploadList> uploadList = new List<UploadList>();
            uploadList = _UploadDataBL.GetReceivedFileListBL((User.Identity as SCSD.Web.SCSDIdentity).UserId);
            return View(uploadList);
        }

        [HttpGet]
        public ActionResult ReceivedFileRemoved(string FileId)
        {
            _UploadDataBL.RemovedReceivedFileBL((User.Identity as SCSD.Web.SCSDIdentity).UserId, FileId);
            return RedirectToAction("ReceivedList");
        }

        [HttpPost]
        public JsonResult GetFilePreview(string FileId)
        {
            UploadList file = new UploadList();
            file = _UploadDataBL.GetUploadFileBL((User.Identity as SCSD.Web.SCSDIdentity).UserId, FileId);
            return Json(new
            {
                data = file
            }, JsonRequestBehavior.AllowGet);
        }
    }
}
