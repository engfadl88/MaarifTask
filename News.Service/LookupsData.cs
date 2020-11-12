using News.Data;
using System.Collections.Generic;
using System.Linq;

namespace News.Service
{
    public static class LookupsData
    {
        public static List<School> Schools
        {
            get
            {
                using (var db = new MaarifDBEntities())
                {
                    return db.Schools.ToList();
                }
            }
        }
    }
}
