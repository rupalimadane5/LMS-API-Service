using System;

namespace LMSAPI.Models.Dto
{
    public class ManageLeaveTransactionDto
    {
        public int ManageleaveId { get; set; }
        public int UserId { get; set; }
        public int YearId { get; set; }
        public DateTime LeaveFrom { get; set; }
        public DateTime leaveTo { get; set; }
        public int LeaveStatus { get; set; }
        public string ApprovedBy { get; set; }
        public bool? Active { get; set; }
        public int LeaveType { get; set; }
        public decimal LeaveDaysCount { get; set; }
        public string LeaveReason { get; set; }
    }
}
