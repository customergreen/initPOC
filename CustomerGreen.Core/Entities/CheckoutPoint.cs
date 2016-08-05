namespace CustomerGreen.Core.Entities
{
    public class CheckoutPoint : BaseEntity
    {
        public long OrgId { get; set; }
        public string CheckoutLocation { get; set; }
    }
}