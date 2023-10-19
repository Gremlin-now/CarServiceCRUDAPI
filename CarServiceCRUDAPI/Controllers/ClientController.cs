using Microsoft.AspNetCore.Mvc;

namespace CarServiceCRUDAPI.Controllers
{
    [ApiController]
    [Route("api/")]
    public class ClientController : Controller
    {
        [HttpGet("client{clientId}/getClientInfo")]
        public Client GetClient(int clientId)
        {
            try
            {
                Response.StatusCode = 200;
                return Storage.Clients[clientId];
            }catch
            {
                Response.StatusCode = 404;
                return new Client();
            }
        }
        [HttpPost("clients/add")]
        public void PostClient(Client client)
        {
            Response.StatusCode = 204;
            Storage.Clients.Add(client);
        }
        [HttpPut("client{clientId}/update")]
        public void UpdateClient(int clientId, Client client)
        {
            try
            {
                Response.StatusCode = 204;
                Storage.Clients[clientId] = client;
            }catch
            {
                Response.StatusCode = 404;
            }
        }
        [HttpDelete("client{clientId}/delete")]
        public void DeleteClient(int clientId)
        {
            try
            {
                Response.StatusCode = 204;
                Storage.Clients.RemoveAt(clientId);
            }catch
            {
                Response.StatusCode = 404;
            }
        }
        [HttpGet("client{clientId}/getAllCars")]
        public List<Car> GetAllCars(int clientId)
        {
            try
            {
                Response.StatusCode = 200;
                return Storage.Clients[clientId].Cars;
            }
            catch
            {
                Response.StatusCode = 404;
                return new List<Car>();
            }
        }
        [HttpGet("client{clientId}/getAllOrders")]
        public List<Order> GetAllOrders(int clientId)
        {
            try
            {
                Response.StatusCode = 200;
                return Storage.Clients[clientId].Orders;
            }
            catch
            {
                Response.StatusCode = 404;
                return new List<Order>();
            }
        }
    }
}
