using CustomerGreen.Core.Data.Repositories;
using CustomerGreen.Core.Entities;

namespace CustomerGreen.Data.Repositories
{
    public class CountryRepository : BaseRepository<Contact>, IContactRepository
    {
        public CountryRepository(IDbContext context) : base(context)
        {
        }
    }

    public class RevenueRepository : BaseRepository<Contact>, IContactRepository
    {
        public RevenueRepository(IDbContext context) : base(context)
        {

        }
    }

    public class PlanRepository : BaseRepository<Contact>, IContactRepository
    {
        public PlanRepository(IDbContext context) : base(context)
        {

        }
    }
}
