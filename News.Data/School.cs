//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace News.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class School
    {
        public School()
        {
            this.NewsSchools = new HashSet<NewsSchool>();
        }
    
        public int Id { get; set; }
        public string SchoolNameAr { get; set; }
        public string SchoolNameEn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
    
        public virtual ICollection<NewsSchool> NewsSchools { get; set; }
    }
}