using System;
using System.ComponentModel.DataAnnotations;

namespace LMSAPI.Models.Dto
{
    public class NewLeaveDto
    {       
        [Required]
        [Range(1,int.MaxValue)]
        public int UserId { get; set; }     
        [Required]
        public DateTime LeaveFrom { get; set; }
        [Required]
        public DateTime leaveTo { get; set; }
        [Required]
        [Range(1,int.MaxValue)]
        public int LeaveStatus { get; set; }
        [Required]
        public string ApprovedBy { get; set; }
        public bool? Active { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int LeaveType { get; set; }
        [Required]
        [Range(0.5,double.MaxValue)]
        public decimal LeaveDaysCount { get; set; }
        [Required]
        public string LeaveReason { get; set; }
    }
}
