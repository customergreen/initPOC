using CustomerGreen.Core.Data;
using CustomerGreen.Core.Entities;
using CustomerGreen.Core.Services;

namespace CustomerGreen.Services.Services
{
    public class BusinessTypeService : BaseService<BusinessType>, IBusinessTypeService
    {
        public BusinessTypeService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}