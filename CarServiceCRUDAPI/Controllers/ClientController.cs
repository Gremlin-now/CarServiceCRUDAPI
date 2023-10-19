using CarServiceCRUDAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarServiceCRUDAPI.Controllers
{
    [ApiController]
    [Route("api/clients")]
    public class ClientController : Controller
    {
        [HttpGet("{clientId}/getClientInfo")]
        public ActionResult GetClient(int clientId)
        {
            try
            {
                return Ok(Storage.Clients[clientId]);
            }catch
            {
                return BadRequest("Клиент не найден");
            }
        }
        [HttpPost("add")]
        public ActionResult PostClient(Client client)
        {
            Storage.Clients[Storage.LastClientsKey++] = client;
            return Ok(client);
        }
        [HttpPut("client{clientId}/update")]
        public ActionResult UpdateClient(int clientId, Client client)
        {
            try
            {
                Storage.Clients[clientId] = client;
                return Ok(client);
            }catch
            {
                return BadRequest("Клиент не найден!");
            }
        }
        [HttpDelete("{clientId}/delete")]
        public ActionResult DeleteClient(int clientId)
        {
            try
            {
                Client? client = null;
                Storage.Clients.Remove(clientId, out client);
                return Ok(client);
            }
            catch
            {
                return BadRequest("Клиент не найден!");
            }
        }
        [HttpGet("{clientId}/getAllCars")]
        public ActionResult GetAllCars(int clientId)
        {
            try
            {
                return Ok(Storage.FindAllCarsForClient(clientId));
            }
            catch
            {
                return BadRequest("Клиент не найден!");
            }
        }
        [HttpGet("{clientId}/getAllOrders")]
        public ActionResult GetAllOrders(int clientId)
        {
            try
            {
                return Ok(Storage.FindAllOrdersForClient(clientId));
            }
            catch
            {
                return BadRequest("Клиент не найден!");
            }
        }
    }
}
