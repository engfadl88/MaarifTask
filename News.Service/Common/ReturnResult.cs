using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace News.Service.Common
{
    public class ReturnResult
    {
        public bool IsValid => ErrorsList == null || ErrorsList.Count == 0;

        public string SuccessMessage { get; set; }

        public List<ErrorModel> ErrorsList { get; private set; }

        public string FirstErrorMessage
        {
            get
            {
                if (ErrorsList != null && ErrorsList.Count > 0)
                {
                    return ErrorsList[0].Message;
                }

                return string.Empty;
            }
        }

        public void AddModelError(ErrorModel errorModel)
        {
            if (ErrorsList == null)
            {
                ErrorsList = new List<ErrorModel>();
            }

            ErrorsList.Add(errorModel);
        }

        public void AddModelError(string key, string errorMessage, string errorCode = null, Exception exception = null)
        {
            ErrorModel errorModel = new ErrorModel
            {
                PropertyName = key,
                Message = errorMessage,
                Code = errorCode,
                Exception = exception
            };

            AddModelError(errorModel);
        }
    }

    public class ReturnResult<T> : ReturnResult
    {
        public T Value { get; set; }

        public ReturnResult()
        {
            Value = default(T);
        }

        public ReturnResult(T defaultValue)
        {
            Value = defaultValue;
        }
    }
}