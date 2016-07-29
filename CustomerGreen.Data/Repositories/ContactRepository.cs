using CustomerGreen.Core.Data.Repositories;
using CustomerGreen.Core.Entities;

namespace CustomerGreen.Data.Repositories
{
    public class ContactRepository : BaseRepository<Contact>, IContactRepository
    {
        public ContactRepository(IDbContext context) : base (context)
        {
        }
    }
}
