using LMSAPI.Common.Constants;
using LMSAPI.Common.CustomExceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net;
using System.Threading.Tasks;

namespace LMSAPI.Common.CustomValidator
{
    public class CustomExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is InvalidLeaveTypeException)
            {
                context.Result = new ObjectResult(new ApiResponse(HttpStatusCode.BadRequest, ApiErrorCodes.InvalidLeaveType, context.Exception));
            }
            else if (context.Exception is InvalidDateException)
            {
                context.Result = new ObjectResult(new ApiResponse(HttpStatusCode.BadRequest, ApiErrorCodes.InvalidFromDateAndToDate, context.Exception));
            }
            else if (context.Exception is NoLeaveBalanceDetailsFoundException)
            {
                context.Result = new ObjectResult(new ApiResponse(HttpStatusCode.BadRequest, ApiErrorCodes.NoLeaveBalanceFound, context.Exception));
            }
            else if (context.Exception is LessLeaveBalanceException)
            {
                context.Result = new ObjectResult(new ApiResponse(HttpStatusCode.BadRequest, ApiErrorCodes.LessLeaveBalance, context.Exception));
            }
            else
            {
                context.Result = new ObjectResult(new ApiResponse(HttpStatusCode.InternalServerError, ApiErrorCodes.InternalServerError, context.Exception));
            }
        }
    }
}
