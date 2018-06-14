using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LMSAPI.Common.CustomExceptions
{
    public class InvalidDateException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }

        public InvalidDateException(string message, Exception innerException)
            : base(message, innerException)
        {
            StatusCode = HttpStatusCode.BadRequest;
        }
    }
}
