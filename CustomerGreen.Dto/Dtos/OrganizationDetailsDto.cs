using System;

namespace CustomerGreen.Dto.Dtos
{
    public class OrganizationDetailsDto : BaseDto
    {
        public string OrgId { get; set; }
        public DateTime? RenewDate { get; set; }
        public DateTime? DueDate { get; set; }
        public bool? PaymentReceived { get; set; }
        public double PaymentDue { get; set; }
        public int LocationCount { get; set; }
    }
}