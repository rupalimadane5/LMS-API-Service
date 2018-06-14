namespace LMSAPI.Models.Domain
{
    public class LeaveStatusMasterDomain : BaseDomain
    {
        public int LeaveStatusId { get; set; }
        public string LeaveStatus { get; set; }
        public bool? Active { get; set; }
    }
}
