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
    }
}
