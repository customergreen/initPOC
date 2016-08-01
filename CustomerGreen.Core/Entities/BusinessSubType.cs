namespace CustomerGreen.Core.Entities
{
    public class BusinessSubType : BaseEntity
    {
        public virtual BusinessType BusinessType { get; set; }
        public string SubType { get; set; }
    }
}