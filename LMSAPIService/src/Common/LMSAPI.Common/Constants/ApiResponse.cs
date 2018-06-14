using System;
using System.Net;

namespace LMSAPI.Common.Constants
{
    public class ApiResponse
    {
        public  HttpStatusCode StatusCode { get; }
        public  object ResponseObject { get;  }
        public string ErrorMessage { get; set; }
        public Exception ExceptionMessage { get; set; }


        public ApiResponse(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }

        public ApiResponse(HttpStatusCode statusCode, object response)
        {
            StatusCode = statusCode;
            ResponseObject = response;
        }
        public ApiResponse(HttpStatusCode statusCode, string errorMessage = null, Exception ex = null)
        {
            StatusCode = statusCode;
            ErrorMessage = errorMessage;
            ExceptionMessage = ex;
        }
    }
}
