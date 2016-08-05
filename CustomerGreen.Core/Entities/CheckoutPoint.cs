namespace CustomerGreen.Core.Entities
{
    public class CheckoutPoint : BaseEntity
    {
        public int OrgId { get; set; }
        public string CheckoutLocation { get; set; }
    }
}