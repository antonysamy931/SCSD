using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SCSD.DTO.Model;
using System.IO;
using SCSD.BLL.BussinessLogic;

namespace SCSD.Web.Controllers
{
    [Authorize]
    public class UploadController : Controller
    {
        private UploadDataBL _UploadDataBL;
        public UploadController()
        {
            _UploadDataBL = new UploadDataBL();
        }

        //
        // GET: /Upload/
        [HttpGet]
        public ActionResult UserUpload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserUpload(HttpPostedFileBase Baner, HttpPostedFileBase FileContent)
        {
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
                    int keysize = 1024;
                    string publicKey;
                    string privatePublicKey;
                    AsymmetricEncryption.GenerateKeys(keysize, out publicKey, out privatePublicKey);
                    uploadFile.AsymmeticKey = privatePublicKey;
                    uploadFile.Type = AsymmetricEncryption.EncryptText(Path.GetExtension(FileContent.FileName).ToLower(), keysize, publicKey);
                    uploadFile.Name = AsymmetricEncryption.EncryptText(Path.GetFileNameWithoutExtension(FileContent.FileName).ToLower(), keysize, publicKey);
                    uploadFile.ApplicaitonType = AsymmetricEncryption.EncryptText(FileContent.ContentType, keysize, publicKey);

                    uploadFile.SymmeticKey = Guid.NewGuid().ToString();
                    byte[] fileData;
                    uploadFile.FileCheckSum = CheckSumGenerator.GetCheckSum(FileContent.InputStream, FileContent.ContentLength, out fileData);

                    if (_UploadDataBL.CheckImageExistBL(uploadFile.FileCheckSum))
                    {
                        ModelState.AddModelError(string.Empty, "File already exist for your account");
                        return View(uploadFile);
                    }
                    else
                    {
                        uploadFile.FileContent = SymmetricEncryption.Encrypt(fileData, uploadFile.SymmeticKey);
                        uploadFile.FileId = Guid.NewGuid().ToString();
                        uploadFile.UserId = User.Identity.Name;
                        if (_UploadDataBL.InsertFileBL(uploadFile))
                        {
                            return RedirectToAction("Dashboard", "Home");
                        }
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

        [HttpGet]
        public ActionResult UploadList()
        {
            List<UploadList> uploadList = new List<UploadList>();
            uploadList = _UploadDataBL.GetUploadFileListBL(User.Identity.Name);
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
            return File(document.File, document.ContentType, document.FileName);
        }
    }
}
