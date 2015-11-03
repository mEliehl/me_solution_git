using Domain.Entities;
using Microsoft.AspNet.Mvc;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IList<Person> Get()
        {
            IList<Person> persons = new List<Person>();
            var person1 = new Person("Marcos Eliehl dos Santos", "meliehl@outlook.com");
            var person2 = new Person("Mariana Guin", "marianaguin@outlook.com");
            persons.Add(person1);
            persons.Add(person2);

            return persons;
        }
    }
}
