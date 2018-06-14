using LMSAPI.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LMSAPI.DataLayer
{
    public class ManageLeaveRepository : IManageLeaveRepository
    {
        private ILMSContext _context;

        public ManageLeaveRepository(ILMSContext dbcontext)
        {
            _context = dbcontext;
        }

        #region Get Methods
        public async Task<List<LeaveDetailsEntity>> GetLeaveDetailsByUserId(int userId)
        {
            var leaveDetails =
             await (from mlm in _context.ManageLeaveTransaction.AsNoTracking()
                    join um in _context.UserMaster.AsNoTracking() on mlm.FkUser equals um.PkUser
                    join ym in _context.YearMaster.AsNoTracking() on mlm.FkYear equals ym.PkYear
                    join lsm in _context.LeaveStatusMaster.AsNoTracking() on mlm.FkLeaveStatus equals lsm.PkLeaveStatus
                    join ltm in _context.LeaveTypeMaster.AsNoTracking() on mlm.FkLeaveType equals ltm.PkLeaveType
                    where ym.BActive == true && mlm.BActive == true && um.PkUser == userId
                    select new LeaveDetailsEntity
                    {
                        PkManageleave = mlm.PkManageleave,
                        SLeaveReason = mlm.LeaveReason,
                        SLeaveType = ltm.SLeaveType,
                        SLeaveStatus = lsm.SLeaveStatus,
                        LeaveDaysCount = mlm.LeaveDaysCount,
                        DtLeaveFrom = mlm.DtLeaveFrom,
                        DtleaveTo = mlm.DtleaveTo
                    }).ToListAsync();

            return leaveDetails;
        }

        public async Task<List<LeaveTypeMasterEntity>> GetLeaveTypes()
        {
            return await _context.LeaveTypeMaster.AsNoTracking().ToListAsync();
        }
        public async Task<YearMasterEntity> GetActiveYear()
        {
            return await _context.YearMaster.AsNoTracking().Where(x => x.BActive == true).SingleOrDefaultAsync();
        }

        public async Task<LeaveBalanceEntity> GetLeaveBalance(int userId, int leaveType)
        {
            return await _context.LeaveBalance.AsNoTracking()
                .Where(x => x.FkUser == userId && x.FkLeaveType == leaveType && x.BActive == true)
                .SingleOrDefaultAsync();
        }
        #endregion

        #region Create/Post methods
        public async Task<ManageLeaveTransactionEntity> InsertLeave(ManageLeaveTransactionEntity _manageLeaveTransactionEntity)
        {
            var yearEntity = await GetActiveYear().ConfigureAwait(false);
            _manageLeaveTransactionEntity.FkYear = yearEntity?.PkYear ?? 0;
            _context.ManageLeaveTransaction.Add(_manageLeaveTransactionEntity);
            return await _context.SaveChangesAsync(default(CancellationToken)).ConfigureAwait(false) > 0 ? _manageLeaveTransactionEntity : null;
        }

        public async Task<bool> UpdateLeaveBalance(LeaveBalanceEntity leaveBalanceEntity)
        {
            _context.LeaveBalance.Update(leaveBalanceEntity);
            return await _context.SaveChangesAsync(default(CancellationToken)).ConfigureAwait(false) > 0;
        }

        //public async Task<bool> UpdateLeaveBalance1(int nleaveConsumed,int leaveType,int userId)
        //{
            
        //}

        #endregion
    }
}
