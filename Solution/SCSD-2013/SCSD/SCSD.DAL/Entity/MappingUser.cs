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
    
    public partial class MappingUser
    {
        public int Id { get; set; }
        public string ParentUser { get; set; }
        public string ChildUser { get; set; }
        public Nullable<bool> Active { get; set; }
        public string FileId { get; set; }
    }
}
