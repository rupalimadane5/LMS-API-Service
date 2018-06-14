using LMSAPI.BusinessLayer;
using LMSAPI.Common.Constants;
using LMSAPI.Common.CustomExceptions;
using LMSAPI.Common.CustomValidator;
using LMSAPI.Mappers.DtoToDomain;
using LMSAPI.Models.Dto.Contract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LMSAPI.Controllers
{
    [Route("api/leave/")]
    
    public class ManageLeaveController : BaseController
    {
        private IManageLeaveManager _manageLeaveManager;

        public ManageLeaveController(IManageLeaveManager manageLeaveManager)
        {
            _manageLeaveManager = manageLeaveManager;
        }

        [HttpGet]
        [Route("leave-details")]
        [ModelStateValidator]
        public async Task<IActionResult> GetLeaveDetails([FromQuery] int userId)
        {
            var msg = new ObjectResult(new ApiResponse(HttpStatusCode.NotImplemented));

            try
            {
                if (userId <= 0)
                {
                    return new ObjectResult(new ApiResponse(HttpStatusCode.BadRequest, ApiErrorCodes.BadRequest));
                }

                var leaveDetails = await _manageLeaveManager.GetLeaveDetails(userId)
                                .ConfigureAwait(false);

                if (leaveDetails == null || leaveDetails.Count()<0)
                {
                    return NotFoundResponse();
                }

                var response = leaveDetails.ToDto();

                msg = new ObjectResult(new ApiResponse(HttpStatusCode.OK, response));

            }
            catch (Exception ex)
            {
                msg = new ObjectResult(new ApiResponse(HttpStatusCode.InternalServerError, "exception occured for GetLeaveDetails", ex));
            }
            return msg;
        }

        [HttpGet]
        [Route("leave-type")]
        public async Task<IActionResult> GetLeaveTypes()
        {
            var msg = new ObjectResult(new ApiResponse(HttpStatusCode.NotImplemented));

            try
            {
                var leaveTypeDetails = await _manageLeaveManager.GetLeaveTypes()
                                .ConfigureAwait(false);

                if (leaveTypeDetails == null || leaveTypeDetails.Count() < 0)
                {
                    return NotFoundResponse();
                }

                var response = leaveTypeDetails.ToDto();

                msg = new ObjectResult(new ApiResponse(HttpStatusCode.OK, response));

            }
            catch (Exception ex)
            {
                msg = new ObjectResult(new ApiResponse(HttpStatusCode.InternalServerError, "exception occured for GetLeaveTypess", ex));
            }
            return msg;
        }

        [HttpPost]
        [Route("add-leave")]
        [ModelStateValidator]
        
        public async Task<IActionResult> AddNewLeave([FromBody] PostLeaveRequest request)
        {
            var msg = new ObjectResult(new ApiResponse(HttpStatusCode.NotImplemented));

                var leaveDetails = await _manageLeaveManager.InsertLeave(request.leaveRequest)
                                .ConfigureAwait(false);

                if (leaveDetails == null )
                {
                    return NotFoundResponse();
                }

                var response = leaveDetails.ToDto();

                msg = new ObjectResult(new ApiResponse(HttpStatusCode.OK, response));

            
            return msg;
        }
    }
}
