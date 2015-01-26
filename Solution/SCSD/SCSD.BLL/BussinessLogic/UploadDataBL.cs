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

        public bool CheckImageExistBL(string Checksum)
        {
            try
            {
                return _uploadData.CheckImageExist(Checksum);
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
    }
}
