using CustomerGreen.Core.Entities;

namespace CustomerGreen.Core.Data.Repositories
{
    public interface ICountryRepository : IRepository<Country>
    {
    }

    public interface IRevenueRepository : IRepository<Revenue>
    {
    }

    public interface IPlanRepository : IRepository<Plan>
    {
    }
}
