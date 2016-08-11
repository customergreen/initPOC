namespace CustomerGreen.Core.Entities
{
    public class Country : BaseEntity
    {
        public string Name { get; set; }
    }

    public class Revenue : BaseEntity
    {
        public string Annual { get; set; }
    }

    public class Plan : BaseEntity
    {
        public string Usage { get; set; }
    }
}
