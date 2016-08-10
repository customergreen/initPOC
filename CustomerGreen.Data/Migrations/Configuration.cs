using System.Data.Entity.Migrations;

namespace CustomerGreen.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<CustomerGreenDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "CustomerGreenDbContext";

        }

        protected override void Seed(CustomerGreenDbContext context)
        {
            //base.Seed(context);
        }
        // Add-Migration -ProjectName CustomerGreen.Data -StartUpProjectName CustomerGreen.Web -Verbose  
        // Update-Database -ProjectName CustomerGreen.Data -StartUpProjectName CustomerGreen.Web -Verbose      
    }
}
