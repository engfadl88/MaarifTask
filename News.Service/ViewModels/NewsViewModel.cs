using News.Data;
using News.Service.CustomDataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using News.Resources;

namespace News.Service.ViewModels
{
    public class NewsViewModel
    {
        public int Id { get; set; }

        [Display(Name = "NewsTitle", ResourceType = typeof(NewsResources))]
        [Required(ErrorMessageResourceType = typeof(NewsResources), ErrorMessageResourceName = "NewsTitleRequired")]
        public string NewsTitle { get; set; }

        [AllowHtml]
        [UIHint("tinymce_jquery_full")]
        [Display(Name = "NewsDetails", ResourceType = typeof(NewsResources))]
        public string NewsDetails { get; set; }

        [Display(Name = "NewsType", ResourceType = typeof(NewsResources))]
        public int NewsType { get; set; }

        [Display(Name = "NewsImage", ResourceType = typeof(NewsResources))]
        public string NewsImage { get; set; }

        [Display(Name = "Attachment", ResourceType = typeof(NewsResources))]
        public string Attachment { get; set; }

        [Display(Name = "NewsLanguage", ResourceType = typeof(NewsResources))]
        [RequiredIfZero(ErrorMessage = "Select the language")]
        public int NewsLanguage { get; set; }

        [Display(Name = "ExpireDate", ResourceType = typeof(NewsResources))]
        [CheckDateRange(ErrorMessage ="Date should be greater than toady date")]
        public DateTime? ExpireDate { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public string currentPeriod { get; set; }

        public int[] SchoolIds { get; set; }
        
    }

    public class NewsSchoolViewModel
    {
        public int Id { get; set; }
        public int NewsId { get; set; }
        public int SchoolId { get; set; }
    }
}
