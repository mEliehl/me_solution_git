using Domain.Entities;
using Domain.Repositories;

namespace Infra.Repositories
{
    internal class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
    }
}
