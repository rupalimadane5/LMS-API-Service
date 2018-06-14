using System;

namespace LMSAPI.Models.Entity
{
    public class BaseEntity
    {
        public DateTime? DtAdded { get; set; }
        public string SAddedBy { get; set; }
        public DateTime? DtUpdated { get; set; }
        public string SUpdatedBy { get; set; }
    }
}
