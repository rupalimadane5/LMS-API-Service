using System.Collections.Generic;

namespace LMSAPI.Models.Entity
{
    public class LeaveStatusMasterEntity : BaseEntity
    {
        public LeaveStatusMasterEntity()
        {
            ManageLeaveTransaction = new HashSet<ManageLeaveTransactionEntity>();
        }

        public int PkLeaveStatus { get; set; }
        public string SLeaveStatus { get; set; }
        public bool? BActive { get; set; }

        public ICollection<ManageLeaveTransactionEntity> ManageLeaveTransaction { get; set; }
    }
}
