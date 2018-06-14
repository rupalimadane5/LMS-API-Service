namespace LMSAPI.Models.Domain
{
    public class LeaveTypeMasterDomain : BaseDomain
    {
        public int LeaveTypeId { get; set; }
        public string LeaveType { get; set; }
        public bool? Active { get; set; }
    }
}
