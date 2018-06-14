using System.Collections.Generic;

namespace LMSAPI.Models.Entity
{
    public class LeaveTypeMasterEntity : BaseEntity
    {
        public LeaveTypeMasterEntity()
        {
            LeaveBalance = new HashSet<LeaveBalanceEntity>();
            ManageLeaveTransaction = new HashSet<ManageLeaveTransactionEntity>();
        }

        public int PkLeaveType { get; set; }
        public string SLeaveType { get; set; }
        public bool? BActive { get; set; }


        public ICollection<LeaveBalanceEntity> LeaveBalance { get; set; }
        public ICollection<ManageLeaveTransactionEntity> ManageLeaveTransaction { get; set; }
    }
}
