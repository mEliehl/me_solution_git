using ApplicationService.CommandsHandlers;
using Domain.Commands;
using Domain.Entities;
using Domain.Repositories;
using Infra;
using Infra.Repositories.Factories;
using Microsoft.AspNet.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using WebApi.ViewModel;


namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        // GET: api/values
        [HttpGet]
        public async Task<IList<Person>> Get()
        {
            using (var uow = UnitOfWork.Create())
            {
                IPersonRepository personRepository = PersonRepositoryFactory.Create(uow.Context);
                return await personRepository.GetAsync(w => true);
            }
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post(PersonViewModel person)
        {
            var handler = new TransactionCommandHandlerDecorator<CreatePersonCommand>(
                new CreatePersonCommandHandler());
            
            await handler.Handle(new CreatePersonCommand(person.Name, person.Email));
            return new HttpStatusCodeResult((int)HttpStatusCode.OK);
        }
    }
}
