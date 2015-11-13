using Domain.Entities;
using Infra.Repositories.Factories;
using Microsoft.AspNet.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        // GET: api/values
        [HttpGet]
        public async Task<IList<Person>> Get()
        {
            var repo = PersonRepositoryFactory.Create();
            IList<Person> persons = new List<Person>();
            var person1 = new Person("Marcos Eliehl dos Santos", "meliehl@outlook.com");
            var person2 = new Person("Mariana Guin", "marianaguin@outlook.com");
            persons.Add(person1);
            persons.Add(person2);

            repo.AddRange(persons);
            await repo.SaveChangesAsync();
            return await repo.GetAsync(w => true);
        }
    }
}
