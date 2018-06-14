using System;

namespace LMSAPI.Models.Dto
{
    public class YearMasterDto
    {
        public int YearId { get; set; }
        public string YearCode { get; set; }
        public DateTime YearStart { get; set; }
        public DateTime YearEnd { get; set; }
        public bool? Active { get; set; }
    }
}
