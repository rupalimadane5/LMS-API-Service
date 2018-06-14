using System;

namespace LMSAPI.Models.Domain
{
    public class BaseDomain
    {
        public DateTime? AddedDate { get; set; }
        public string AddedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
