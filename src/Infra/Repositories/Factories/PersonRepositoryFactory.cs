using Domain.Repositories;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Repositories.Factories
{
    public class PersonRepositoryFactory
    {
        public static IPersonRepository Create(DbContext Context)
        {
            return new PersonRepository(Context);
        }
    }
}
