using CarServiceCRUDAPI.Models;
using CarServiceCRUDAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CarServiceCRUDAPI.Controllers
{
    [ApiController]
    [Route("api/clients")]
    public class ClientController : Controller
    {
        IBaseRepository<Client> clientRepository;

        public ClientController(IBaseRepository<Client> clientRepository)
        {
            this.clientRepository = clientRepository;
        }
        [HttpGet("{clientId}/getClientInfo")]
        public ActionResult GetClient(int clientId)
        {
            return Ok(clientRepository.Get(clientId));
        }
        [HttpPost("add")]
        public ActionResult PostClient(Client client)
        {
            return Ok(clientRepository.Create(client));
        }
        [HttpPut("client{clientId}/update")]
        public ActionResult UpdateClient(int clientId, Client client)
        {
            return Ok(clientRepository.Update(client, clientId));
        }
        [HttpDelete("{clientId}/delete")]
        public ActionResult DeleteClient(int clientId)
        {
            return Ok(clientRepository.Delete(clientId));
        }
    }
}
