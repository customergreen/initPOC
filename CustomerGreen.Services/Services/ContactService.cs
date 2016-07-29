using CustomerGreen.Core.Data;
using CustomerGreen.Core.Entities;
using CustomerGreen.Core.Services;

namespace CustomerGreen.Services.Services
{
    public class ContactService : BaseService<Contact>, IContactService
    {
        public ContactService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
