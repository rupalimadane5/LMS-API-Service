using LMSAPI.Common.Constants;
using LMSAPI.Common.CustomValidator;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LMSAPI.Controllers
{
    [CustomException]
    public class BaseController : Controller
    {
        public BaseController()
        {

        }

        public ObjectResult NotFoundResponse()
        {
            return new ObjectResult(new ApiResponse(HttpStatusCode.NotFound, ApiErrorCodes.NotFound));
        }
    }
}