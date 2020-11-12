using System;
using System.ComponentModel.DataAnnotations;

namespace News.Service.CustomDataAnnotations
{
    public class RequiredIfZeroAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                var inputvalue = (int)value;

                return (inputvalue != 0);
            }
            else
                return false;

        }
    }
}
