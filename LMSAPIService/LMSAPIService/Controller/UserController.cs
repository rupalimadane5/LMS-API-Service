using LMSAPI.BusinessLayer;
using LMSAPI.Common.Constants;
using LMSAPI.Common.CustomValidator;
using LMSAPI.Mappers.DtoToDomain;
using LMSAPI.Models.Dto.Contract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace LMSAPI.Controllers
{
    [Route("api/users/")]
    public class UserController : BaseController
    {
        private IUserManager _userManager;
      
        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        [Route("login")]
        [ModelStateValidator]
        public async Task<IActionResult> GetUser([FromQuery] GetUserLoginRequest request)
        {
            var msg = new ObjectResult(new ApiResponse(HttpStatusCode.NotImplemented));

            try
            {
                var userDomain = await _userManager.GetUserInformation(request.UserName, request.Password)
                                .ConfigureAwait(false);

                if (userDomain == null)
                {
                    return NotFoundResponse();
                }

                var response = userDomain.ToDto();

                msg = new ObjectResult(new ApiResponse(HttpStatusCode.OK, response));

            }
            catch (Exception ex)
            {
                msg = new ObjectResult(new ApiResponse(HttpStatusCode.InternalServerError, "exception occured for GetUser", ex));
            }
            return msg;
        }
    }
}
