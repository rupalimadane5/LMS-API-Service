using LMSAPI.Models.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMSAPI.DataLayer
{
    public interface IManageLeaveRepository
    {
         Task<List<LeaveDetailsEntity>> GetLeaveDetailsByUserId(int userId);
        Task<List<LeaveTypeMasterEntity>> GetLeaveTypes();
        Task<YearMasterEntity> GetActiveYear();
        Task<LeaveBalanceEntity> GetLeaveBalance(int userId, int leaveType);
        Task<ManageLeaveTransactionEntity> InsertLeave(ManageLeaveTransactionEntity _manageLeaveTransactionEntity);
        Task<bool> UpdateLeaveBalance(LeaveBalanceEntity leaveBalanceEntity);
    }
}
