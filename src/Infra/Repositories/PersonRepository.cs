using Domain.Entities;
using Domain.Repositories;
using Microsoft.Data.Entity;

namespace Infra.Repositories
{
    internal class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(DbContext context)
            :base(context)
        {

        }
    }
}
