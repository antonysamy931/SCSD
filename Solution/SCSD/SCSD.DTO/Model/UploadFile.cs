using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCSD.DTO.Model
{
    public class UploadFile
    {
        public string FileId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string ApplicaitonType { get; set; }
        public byte[] FileContent { get; set; }
        public byte[] Baner { get; set; }
        public string BanerApplicationType { get; set; }
        public string SymmeticKey { get; set; }
        public string AsymmeticKey { get; set; }
        public string FileCheckSum { get; set; }
        public string UserId { get; set; }
    }

    public class UploadList
    {
        public string FileId { get; set; }
        public string FileName { get; set; }
        public string BanarId { get; set; }
        public string Description { get; set; }
    }

    public class DownloadDocument
    {
        public byte[] File { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
    }
}
