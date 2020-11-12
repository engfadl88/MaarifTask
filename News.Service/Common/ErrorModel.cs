using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace News.Service.Common
{
    public class ErrorModel
    {
        public string Code { get; set; }

        public string Message { get; set; }

        public string PropertyName { get; set; }

        public Exception Exception { get; set; }

        public List<KeyValuePair<string, string>> AdditionalData { get; private set; }

        public void AddAdditionalData(string key, string value)
        {
            if (AdditionalData == null)
            {
                AdditionalData = new List<KeyValuePair<string, string>>();
            }

            AdditionalData.Add(new KeyValuePair<string, string>(key, value));
        }
    }
}