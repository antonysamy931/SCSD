//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SCSD.DAL.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class FileMetadata
    {
        public FileMetadata()
        {
            this.MappingFileBanars = new HashSet<MappingFileBanar>();
            this.MappingFileContents = new HashSet<MappingFileContent>();
            this.MappingFileKeys = new HashSet<MappingFileKey>();
            this.MappingFileUsers = new HashSet<MappingFileUser>();
        }
    
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string ApplicationType { get; set; }
        public Nullable<bool> Active { get; set; }
    
        public virtual ICollection<MappingFileBanar> MappingFileBanars { get; set; }
        public virtual ICollection<MappingFileContent> MappingFileContents { get; set; }
        public virtual ICollection<MappingFileKey> MappingFileKeys { get; set; }
        public virtual ICollection<MappingFileUser> MappingFileUsers { get; set; }
    }
}
