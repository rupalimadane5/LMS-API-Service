using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LMSAPI.Common.CustomExceptions
{
    public class NoLeaveBalanceDetailsFoundException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }

        public NoLeaveBalanceDetailsFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
            StatusCode = HttpStatusCode.NotFound;
        }
    }
}
