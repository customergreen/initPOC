namespace CustomerGreen.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<CustomerGreenDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "CustomerGreenDbContext";
        }

        protected override void Seed(CustomerGreenDbContext context)
        {
            base.Seed(context);
        }
    }
}
