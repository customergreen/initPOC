using CustomerGreen.Core.Data;
using CustomerGreen.Core.Entities;
using CustomerGreen.Core.Services;

namespace CustomerGreen.Services.Services
{
    public class BusinessSubTypeService : BaseService<BusinessSubType>, IBusinessSubTypeService
    {
        public BusinessSubTypeService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}