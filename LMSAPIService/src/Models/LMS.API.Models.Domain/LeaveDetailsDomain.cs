using System;

namespace LMSAPI.Models.Domain
{
    public class LeaveDetailsDomain
    {
        public int ManageleaveId { get; set; }
        public string LeaveReason { get; set; }
        public string LeaveType { get; set; }
        public string LeaveStatus { get; set; }
        public decimal LeaveDaysCount { get; set; }
        public DateTime LeaveFrom { get; set; }
        public DateTime LeaveTo { get; set; }
    }
}
