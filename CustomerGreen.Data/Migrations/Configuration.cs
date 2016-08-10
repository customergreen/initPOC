namespace CustomerGreen.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<CustomerGreenDbContext>
    {
        //private readonly bool _pendingMigrations;

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "CustomerGreenDbContext";

            //var migrator = new DbMigrator(this);
            //_pendingMigrations = migrator.GetPendingMigrations().Any();
        }

        protected override void Seed(CustomerGreenDbContext context)
        {
            //if (!_pendingMigrations) return;

            //InitializeLicenseTypes(context);
            //InitializeBusinessTypes(context);
            //InitializeBusinessSubTypes(context);
            //InitializeOrgnUser(context);

            base.Seed(context);
        }
    }
}