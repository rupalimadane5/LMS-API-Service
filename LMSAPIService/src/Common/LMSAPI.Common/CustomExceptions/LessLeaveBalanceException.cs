using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LMSAPI.Common.CustomExceptions
{
    public class LessLeaveBalanceException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }

        public LessLeaveBalanceException(string message, Exception innerException)
            : base(message, innerException)
        {
            StatusCode = HttpStatusCode.BadRequest;
        }
    }
}
