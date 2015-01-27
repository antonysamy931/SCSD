using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCSD.DTO.Model;
using SCSD.DAL.Entity;

namespace SCSD.DAL.DataLogic
{
    public class UploadData
    {
        private SCSDEntities _entity;
        public UploadData()
        {
            _entity = new SCSDEntities();
        }

        public bool CheckImageExist(string Checksum)
        {
            try
            {
                return _entity.MappingFileCheckSums.Any(x => x.FileCheckSum == Checksum);
            }
            catch
            {
                throw;
            }
        }

        public bool InsertFile(UploadFile uploadFile)
        {
            try
            {
                FileMetadata fileMetaData = new FileMetadata();
                fileMetaData.Active = true;
                fileMetaData.ApplicationType = uploadFile.ApplicaitonType;
                fileMetaData.Description = uploadFile.Description;
                fileMetaData.Name = uploadFile.Name;
                fileMetaData.Type = uploadFile.Type;
                fileMetaData.Id = uploadFile.FileId;
                _entity.FileMetadatas.Add(fileMetaData);
                _entity.SaveChanges();

                MappingFileCheckSum mappingFileChecksum = new MappingFileCheckSum();
                mappingFileChecksum.FileCheckSum = uploadFile.FileCheckSum;
                mappingFileChecksum.FileId = fileMetaData.Id;
                mappingFileChecksum.Active = true;
                _entity.MappingFileCheckSums.Add(mappingFileChecksum);

                MappingFileUser mappingFileUser = new MappingFileUser();
                mappingFileUser.Active = true;
                mappingFileUser.FileId = fileMetaData.Id;
                mappingFileUser.UserId = uploadFile.UserId;
                _entity.MappingFileUsers.Add(mappingFileUser);

                FileKey fileKey = new FileKey();
                fileKey.Active = true;
                fileKey.ASYMKey = uploadFile.AsymmeticKey;
                fileKey.SYMKey = uploadFile.SymmeticKey;
                _entity.FileKeys.Add(fileKey);
                _entity.SaveChanges();

                MappingFileKey mappingFileKey = new MappingFileKey();
                mappingFileKey.Active = true;
                mappingFileKey.FileId = fileMetaData.Id;
                mappingFileKey.KeyId = fileKey.Id;
                _entity.MappingFileKeys.Add(mappingFileKey);

                FileBanar fileBanar = new FileBanar();
                fileBanar.Active = true;
                fileBanar.Banar = uploadFile.Baner;
                fileBanar.Type = uploadFile.BanerApplicationType;
                _entity.FileBanars.Add(fileBanar);
                _entity.SaveChanges();

                MappingFileBanar mappingFileBanar = new MappingFileBanar();
                mappingFileBanar.Active = true;
                mappingFileBanar.BanarId = fileBanar.Id;
                mappingFileBanar.FileId = fileMetaData.Id;
                _entity.MappingFileBanars.Add(mappingFileBanar);

                FileContent fileContent = new FileContent();
                fileContent.Active = true;
                fileContent.FileData = uploadFile.FileContent;
                fileContent.FileId = fileMetaData.Id;
                _entity.FileContents.Add(fileContent);
                _entity.SaveChanges();

                MappingFileContent mappingFileContent = new MappingFileContent();
                mappingFileContent.Active = true;
                mappingFileContent.ContentId = fileContent.Id;
                mappingFileContent.FileId = fileMetaData.Id;
                _entity.MappingFileContents.Add(mappingFileContent);
                _entity.SaveChanges();


                return true;
            }
            catch
            {
                throw;
            }
        }

        public List<UploadList> GetUploadFileList(string UserId)
        {
            List<UploadList> uploadFilelist = new List<UploadList>();
            try
            {
                var ownFileIds = _entity.MappingFileUsers.Where(x => x.UserId == UserId && x.Active == true).Select(x => x.FileId).ToList();
                var shardFileIds = _entity.MappingUsers.Where(x => x.ChildUser == UserId && x.Active == true).Select(x => x.FileId).ToList();
                if (shardFileIds.Count > 0)
                {
                    ownFileIds.AddRange(shardFileIds);
                }
                ListGenerate(ownFileIds, out uploadFilelist);
                return uploadFilelist;
            }
            catch
            {
                throw;
            }
        }

        public void ListGenerate(List<string> FileIds, out List<UploadList> UploadLists)
        {
            List<UploadList> uploadFilelist = new List<UploadList>();
            try
            {
                foreach (var item in FileIds)
                {
                    UploadList uList = new UploadList();
                    uList.FileId = item;

                    var fileKeys = (from o in _entity.FileKeys
                                    join oo in _entity.MappingFileKeys
                                    on o.Id equals oo.KeyId
                                    where oo.FileId == item
                                    select new { o.ASYMKey }).FirstOrDefault();

                    var fileMetadata = _entity.FileMetadatas.Where(x => x.Id == item).FirstOrDefault();
                    if (fileMetadata != null)
                    {
                        uList.FileName = AsymmetricEncryption.DecryptText(fileMetadata.Name, 1024, fileKeys.ASYMKey);
                        uList.Description = fileMetadata.Description;
                    }

                    var fileBanardetail = (from o in _entity.FileBanars
                                           join oo in _entity.MappingFileBanars
                                           on o.Id equals oo.BanarId
                                           where
                                           oo.FileId == item
                                           select new { o.Id }).FirstOrDefault();
                    if (fileBanardetail != null)
                    {
                        uList.BanarId = fileBanardetail.Id.ToString();
                    }
                    uploadFilelist.Add(uList);
                }
                UploadLists = uploadFilelist;
            }
            catch
            {
                throw;
            }
        }

        public byte[] BanarData(string BanarId)
        {
            try
            {
                int banarId = Convert.ToInt32(BanarId);
                return _entity.FileBanars.Where(x => x.Id == banarId).Select(x => x.Banar).FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }

        public DownloadDocument GetDocument(string FileId)
        {
            try
            {
                DownloadDocument document = new DownloadDocument();
                var fileKeys = (from o in _entity.FileKeys
                                join oo in _entity.MappingFileKeys
                                on o.Id equals oo.KeyId
                                where oo.FileId == FileId
                                select new { o.ASYMKey, o.SYMKey }).FirstOrDefault();

                var fileMetadata = _entity.FileMetadatas.Where(x => x.Id == FileId).FirstOrDefault();
                if (fileMetadata != null)
                {
                    document.FileName = AsymmetricEncryption.DecryptText(fileMetadata.Name, 1024, fileKeys.ASYMKey);
                    document.ContentType = AsymmetricEncryption.DecryptText(fileMetadata.ApplicationType, 1024, fileKeys.ASYMKey);
                }

                var fileContent = (from o in _entity.FileContents
                                   join oo in _entity.MappingFileContents
                                   on o.Id equals oo.ContentId
                                   where oo.FileId == FileId
                                   select new { o.FileData }).FirstOrDefault();
                document.File = SymmetricEncryption.Decrypt(fileContent.FileData, fileKeys.SYMKey);
                return document;
            }
            catch
            {
                throw;
            }
        }
    }
}
