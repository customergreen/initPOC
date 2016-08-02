using CustomerGreen.Core.Data;
using CustomerGreen.Core.Entities;
using CustomerGreen.Core.Services;

namespace CustomerGreen.Services.Services
{
    public class OrganizationService : BaseService<OrganizationProfile>, IOrganizationService
    {
        public OrganizationService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}