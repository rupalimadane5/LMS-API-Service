using LMSAPI.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Threading;
using System.Threading.Tasks;

namespace LMSAPI.DataLayer
{
    public interface ILMSContext
    {
        DbSet<LeaveBalanceEntity> LeaveBalance { get; set; }
        DbSet<LeaveStatusMasterEntity> LeaveStatusMaster { get; set; }
        DbSet<LeaveTypeMasterEntity> LeaveTypeMaster { get; set; }
        DbSet<ManageLeaveTransactionEntity> ManageLeaveTransaction { get; set; }
        DbSet<UserMasterEntity> UserMaster { get; set; }
        DbSet<YearMasterEntity> YearMaster { get; set; }
        DatabaseFacade Database { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
