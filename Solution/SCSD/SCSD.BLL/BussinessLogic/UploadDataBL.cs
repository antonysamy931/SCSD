using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCSD.DTO.Model;
using SCSD.DAL.DataLogic;

namespace SCSD.BLL.BussinessLogic
{
    public class UploadDataBL
    {
        private UploadData _uploadData;
        public UploadDataBL()
        {
            _uploadData = new UploadData();
        }

        public bool CheckImageExistBL(string Checksum,string UserId)
        {
            try
            {
                return _uploadData.CheckImageExist(Checksum,UserId);
            }
            catch
            {
                throw;
            }
        }

        public bool InsertFileBL(UploadFile uploadFile)
        {
            try
            {
                return _uploadData.InsertFile(uploadFile);
            }
            catch
            {
                throw;
            }
        }

        public List<UploadList> GetUploadFileListBL(string UserId)
        {
            try
            {
                return _uploadData.GetUploadFileList(UserId);
            }
            catch
            {
                throw;
            }
        }

        public UploadList GetUploadFileBL(string UserId, string FileId)
        {
            try
            {
                return _uploadData.GetUploadFile(UserId, FileId);
            }
            catch
            {
                throw;
            }
        }

        public byte[] BanarDataBL(string BanarId)
        {
            try
            {
                return _uploadData.BanarData(BanarId);
            }
            catch
            {
                throw;
            }
        }

        public DownloadDocument GetDocumentBL(string FileId)
        {
            try
            {
                return _uploadData.GetDocument(FileId);
            }
            catch
            {
                throw;
            }
        }
        public void ShareUserBL(string ParentUser, string[] Users, string fileId)
        {
            try
            {
                _uploadData.ShareUser(ParentUser, Users, fileId);
            }
            catch
            {
                throw;
            }
        }

        public List<UploadList> GetReceivedFileListBL(string UserId)
        {
            try
            {
                return _uploadData.GetReceivedFileList(UserId);
            }
            catch
            {
                throw;
            }
        }

        public void DeleteFileBL(string FileId)
        {
            try
            {
                _uploadData.DeleteFile(FileId);
            }
            catch
            {
                throw;
            }
        }

        public void RemovedReceivedFileBL(string UserId, string FileId)
        {
            try
            {
                _uploadData.RemovedReceivedFile(UserId, FileId);
            }
            catch
            {
                throw;
            }
        }

        public List<UploadList> GetAllFileListBL()
        {
            try
            {
                return _uploadData.GetAllFileList();
            }
            catch
            {
                throw;
            }
        }
    }
}
