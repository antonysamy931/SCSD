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
    
    public partial class UserGroupType
    {
        public UserGroupType()
        {
            this.MappingUserGroups = new HashSet<MappingUserGroup>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<bool> Active { get; set; }
    
        public virtual ICollection<MappingUserGroup> MappingUserGroups { get; set; }
    }
}
