namespace LMSAPI.Models.Dto
{
    public class LeaveBalanceDto
    {
        public int LeaveBalanceId { get; set; }
        public int LeaveTypeId { get; set; }
        public int UserId { get; set; }
        public int YearId { get; set; }
        public decimal? LeaveCredit { get; set; }
        public decimal? LeaveConsumed { get; set; }
        public decimal? LeaveBalance { get; set; }
        public bool? Active { get; set; }
    }
}
