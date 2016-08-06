using CustomerGreen.Core.Data;
using CustomerGreen.Core.Entities;
using CustomerGreen.Core.Services;

namespace CustomerGreen.Services.Services
{
    public class LicenseService : BaseService<LicenseType>, ILicenseTypeService
    {
        public LicenseService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}