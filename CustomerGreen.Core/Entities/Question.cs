namespace CustomerGreen.Core.Entities
{
    public class Question : BaseEntity
    {
        public long OrgId { get; set; }
        public string CategoryKey { get; set; }
        public string FeedbackQuestion { get; set; }
    }
}