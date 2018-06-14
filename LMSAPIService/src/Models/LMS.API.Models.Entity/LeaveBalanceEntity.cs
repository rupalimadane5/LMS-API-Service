namespace LMSAPI.Models.Entity
{
    public class LeaveBalanceEntity : BaseEntity
    {
        public int PkLeaveBalance { get; set; }
        public int FkLeaveType { get; set; }
        public int FkUser { get; set; }
        public int FkYear { get; set; }
        public decimal? NLeaveCredit { get; set; }
        public decimal? NLeaveConsumed { get; set; }
        public decimal? NLeaveBalance { get; set; }
        public bool? BActive { get; set; }

        public LeaveTypeMasterEntity FkLeaveTypeNavigation { get; set; }
        public UserMasterEntity FkUserNavigation { get; set; }
        public YearMasterEntity FkYearNavigation { get; set; }
    }
}
