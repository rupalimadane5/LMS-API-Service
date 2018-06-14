using System.Collections.Generic;

namespace LMSAPI.Models.Entity
{
    public class UserMasterEntity : BaseEntity
    {
        public UserMasterEntity()
        {
            LeaveBalance = new HashSet<LeaveBalanceEntity>();
            ManageLeaveTransaction = new HashSet<ManageLeaveTransactionEntity>();
        }

        public int PkUser { get; set; }
        public string SUserName { get; set; }
        public string SPassword { get; set; }
        public bool? BActive { get; set; }

        public ICollection<LeaveBalanceEntity> LeaveBalance { get; set; }
        public ICollection<ManageLeaveTransactionEntity> ManageLeaveTransaction { get; set; }
    }
}
