using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Service.ViewModels
{
    public class SchoolViewModel
    {
        public int Id { get; set; }
        public string SchoolNameAr { get; set; }
        public string SchoolNameEn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
