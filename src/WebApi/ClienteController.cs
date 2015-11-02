using Domain;
using Microsoft.AspNet.Mvc;
using System.Collections.Generic;

namespace WebApi
{
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IList<Cliente> Get()
        {
            IList<Cliente> clientes = new List<Cliente>();
            var cliente1 = new Cliente("Marcos Eliehl dos Santos", "meliehl@outlook.com");
            var cliente2 = new Cliente("Mariana Guin", "marianaguin@outlook.com");
            clientes.Add(cliente1);
            clientes.Add(cliente2);

            return clientes;
        }
    }
}
