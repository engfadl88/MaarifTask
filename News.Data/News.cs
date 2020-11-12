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
    
    public partial class News
    {
        public News()
        {
            this.NewsSchools = new HashSet<NewsSchool>();
        }
    
        public int Id { get; set; }
        public string NewsTitle { get; set; }
        public string NewsDetails { get; set; }
        public Nullable<int> NewsType { get; set; }
        public string NewsImage { get; set; }
        public string Attachment { get; set; }
        public int NewsLanguage { get; set; }
        public Nullable<System.DateTime> ExpireDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
    
        public virtual ICollection<NewsSchool> NewsSchools { get; set; }
    }
}
