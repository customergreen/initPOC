using CustomerGreen.Core.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CustomerGreen.Data.Configurations
{
    public class CountryConfiguration : EntityTypeConfiguration<Country>
    {
        public CountryConfiguration()
        {
            Property(c => c.Name).IsRequired().HasMaxLength(100);
        }
    }

    public class RevenueConfiguration : EntityTypeConfiguration<Revenue>
    {
        public RevenueConfiguration()
        {
            Property(c => c.Annual).IsRequired().HasMaxLength(100);
        }
    }

    public class PlanConfiguration : EntityTypeConfiguration<Plan>
    {
        public PlanConfiguration()
        {
            Property(c => c.Usage).IsRequired().HasMaxLength(100);
        }
    }
}
