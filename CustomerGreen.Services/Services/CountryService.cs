using CustomerGreen.Core.Data;
using CustomerGreen.Core.Entities;
using CustomerGreen.Core.Services;

namespace CustomerGreen.Services.Services
{
    public class CountryService : BaseService<Country>, ICountryService
    {
        public CountryService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }
    }

    public class RevenueService : BaseService<Revenue>, IRevenueService
    {
        public RevenueService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }
    }

    public class PlanService : BaseService<Plan>, IPlanService
    {
        public PlanService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }
    }
}
