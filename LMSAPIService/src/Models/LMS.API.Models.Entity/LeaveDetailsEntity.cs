using System;

namespace LMSAPI.Models.Entity
{
    public class LeaveDetailsEntity
    {
        public int PkManageleave { get; set; }
        public string SLeaveReason { get; set; }
        public string SLeaveType { get; set; }
        public string SLeaveStatus { get; set; }
        public decimal LeaveDaysCount { get; set; }
        public DateTime DtLeaveFrom { get; set; }
        public DateTime DtleaveTo { get; set; }
    }
}
