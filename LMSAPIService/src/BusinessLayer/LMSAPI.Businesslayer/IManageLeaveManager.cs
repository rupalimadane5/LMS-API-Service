using LMSAPI.Models.Domain;
using LMSAPI.Models.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMSAPI.BusinessLayer
{
    public interface IManageLeaveManager
    {
        Task<List<LeaveDetailsDomain>> GetLeaveDetails(int userId);
        Task<List<LeaveTypeMasterDomain>> GetLeaveTypes();
        Task<ManageLeaveTransactionDomain> InsertLeave(NewLeaveDto request);
    }
}
