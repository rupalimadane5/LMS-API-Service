using System;
using System.Collections.Generic;

namespace LMSAPI.Models.Entity
{
    public class YearMasterEntity : BaseEntity
    {
        public YearMasterEntity()
        {
            LeaveBalance = new HashSet<LeaveBalanceEntity>();
            ManageLeaveTransaction = new HashSet<ManageLeaveTransactionEntity>();
        }

        public int PkYear { get; set; }
        public string SYearCode { get; set; }
        public DateTime SYearStart { get; set; }
        public DateTime SYearEnd { get; set; }
        public bool? BActive { get; set; }


        public ICollection<LeaveBalanceEntity> LeaveBalance { get; set; }
        public ICollection<ManageLeaveTransactionEntity> ManageLeaveTransaction { get; set; }
    }
}
