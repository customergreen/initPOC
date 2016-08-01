using System;

namespace CustomerGreen.Core.Entities
{
    public class OrganizationDetails : AuditableEntity
    {
        public long OrgId { get; set; }
        public DateTime? RenewDate { get; set; }
        public DateTime? DueDate { get; set; }
        public bool? PaymentReceived { get; set; }
        public double PaymentDue { get; set; }
        public int LocationCount { get; set; }
    }
}