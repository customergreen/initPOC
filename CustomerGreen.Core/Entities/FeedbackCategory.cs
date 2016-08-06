namespace CustomerGreen.Core.Entities
{
    public class FeedbackCategory : BaseEntity
    {
        public long OrgId { get; set; }
        public string CategoryKey { get; set; }
        public string Category { get; set; }
    }
}
