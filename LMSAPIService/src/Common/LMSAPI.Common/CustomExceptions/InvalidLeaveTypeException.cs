using System;
using System.Net;

namespace LMSAPI.Common.CustomExceptions
{
    public class InvalidLeaveTypeException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }

        public InvalidLeaveTypeException( string message, Exception innerException)
            : base(message, innerException)
        {
            StatusCode = HttpStatusCode.BadRequest;
        }
    }
}
