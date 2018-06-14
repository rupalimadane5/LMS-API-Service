using LMSAPI.Common.Constants;
using LMSAPI.Common.CustomExceptions;
using LMSAPI.Common.CustomValidator;
using LMSAPI.DataLayer;
using LMSAPI.Mappers.DtoToDomain;
using LMSAPI.Mappers.EntityToDomain;
using LMSAPI.Models.Domain;
using LMSAPI.Models.Dto;
using LMSAPI.Models.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMSAPI.BusinessLayer
{
    public class ManageLeaveManager : IManageLeaveManager
    {
        private IManageLeaveRepository _manageLeaveRepository;
        public ManageLeaveManager(IManageLeaveRepository manageLeaveRepository)
        {
            _manageLeaveRepository = manageLeaveRepository;
        }

        public async Task<List<LeaveDetailsDomain>> GetLeaveDetails(int userId)
        {
            var leaveDetailsEntity = await _manageLeaveRepository.GetLeaveDetailsByUserId(userId)
                 .ConfigureAwait(false);
            if (leaveDetailsEntity != null && leaveDetailsEntity.Count() > 0)
            {
                return leaveDetailsEntity.ToDomain();
            }

            return null;
        }

        public async Task<List<LeaveTypeMasterDomain>> GetLeaveTypes()
        {
            var leaveTypeEntity = await _manageLeaveRepository.GetLeaveTypes()
                 .ConfigureAwait(false);
            if (leaveTypeEntity != null && leaveTypeEntity.Count() > 0)
            {
                return leaveTypeEntity.ToDomain();
            }

            return null;
        }

        public async Task<ManageLeaveTransactionDomain> InsertLeave(NewLeaveDto request)
        {
            if (!IsValidRequest(request))
            {
                return null;
            }

            var leaveBalanceEntity = await DoesUserHaveLeaveBalance(request);
            var manageLeaveEntity = await AddLeave(request);

            if (await UpdateLeaveBalance(request, leaveBalanceEntity))
            {
                if (manageLeaveEntity != null && manageLeaveEntity.PkManageleave > 0)
                {
                    return manageLeaveEntity.ToDomain();
                }
            }

            return null;
        }

        private bool IsValidRequest(NewLeaveDto request)
        {
            if (request.LeaveType <= 0)
            {
                throw new InvalidLeaveTypeException(ApiErrorCodes.InvalidLeaveType, null);
            }

            if (request.LeaveFrom > request.leaveTo)
            {
                throw new InvalidDateException(ApiErrorCodes.InvalidFromDateAndToDate, null);
            }

            return true;
        }
        private async Task<LeaveBalanceEntity> DoesUserHaveLeaveBalance(NewLeaveDto request)
        {
            var leaveBalanceEntity = await _manageLeaveRepository.GetLeaveBalance(request.UserId, request.LeaveType).ConfigureAwait(false);
            if (leaveBalanceEntity == null)
            {
                throw new NoLeaveBalanceDetailsFoundException(ApiErrorCodes.NoLeaveBalanceFound, null);
            }
            else if (leaveBalanceEntity.NLeaveBalance < request.LeaveDaysCount)
            {
                throw new LessLeaveBalanceException(ApiErrorCodes.LessLeaveBalance, null);
            }
            return leaveBalanceEntity;
        }
        private async Task<ManageLeaveTransactionEntity> AddLeave(NewLeaveDto request)
        {
            var manageLeaveTransactionDomain = request.ToDomain();
            var manageLeaveEntity = manageLeaveTransactionDomain.ToEntity();

            manageLeaveEntity = await _manageLeaveRepository.InsertLeave(manageLeaveEntity)
                .ConfigureAwait(false);
            return manageLeaveEntity;
        }
        private async Task<bool> UpdateLeaveBalance(NewLeaveDto request, LeaveBalanceEntity leaveBalanceEntity)
        {
            leaveBalanceEntity = CalculateLeaveBalance(request, leaveBalanceEntity);
            return await _manageLeaveRepository.UpdateLeaveBalance(leaveBalanceEntity).ConfigureAwait(false);
        }

        private LeaveBalanceEntity CalculateLeaveBalance(NewLeaveDto request, LeaveBalanceEntity leaveBalanceEntity)
        {
            leaveBalanceEntity.NLeaveConsumed = leaveBalanceEntity.NLeaveConsumed + request.LeaveDaysCount;
            leaveBalanceEntity.NLeaveBalance = leaveBalanceEntity.NLeaveBalance - request.LeaveDaysCount;
            return leaveBalanceEntity;
        }

      
    }
}
