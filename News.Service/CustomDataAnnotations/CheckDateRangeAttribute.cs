using System;
using System.ComponentModel.DataAnnotations;

namespace News.Service.CustomDataAnnotations
{
    public class CheckDateRangeAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                var inputDate = (DateTime)value;

                return (inputDate > DateTime.Now);
            }
            else
                return false;

        }
    }
}
