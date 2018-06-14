using System;

namespace LMSAPI.Models.Entity
{
    public class ManageLeaveTransactionEntity : BaseEntity
    {
        public int PkManageleave { get; set; }
        public int FkUser { get; set; }
        public int FkYear { get; set; }
        public DateTime DtLeaveFrom { get; set; }
        public DateTime DtleaveTo { get; set; }
        public int FkLeaveStatus { get; set; }
        public string SApprovedBy { get; set; }
        public bool? BActive { get; set; }
        public int FkLeaveType { get; set; }
        public decimal LeaveDaysCount { get; set; }
        public string LeaveReason { get; set; }

        public LeaveStatusMasterEntity FkLeaveStatusNavigation { get; set; }
        public UserMasterEntity FkUserNavigation { get; set; }
        public YearMasterEntity FkYearNavigation { get; set; }
        public LeaveTypeMasterEntity FkLeaveTypeNavigation { get; set; }
    }
}
