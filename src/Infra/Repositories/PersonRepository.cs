using Domain.Entities;
using Domain.Repositories;

namespace Infra.Repositories
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
    }
}
