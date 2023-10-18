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
                return Storage.Clients[clientId];
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new Client();
            }
        }
        [HttpPost("clients/add")]
        public void PostClient(Client client)
        {
            Storage.Clients.Add(client);
        }
        [HttpPut("client{clientId}/update")]
        public void UpdateClient(int clientId, Client client)
        {
            try
            {
                Storage.Clients[clientId] = client;
            }catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        [HttpDelete("client{clientId}/delete")]
        public void DeleteClient(int clientId)
        {
            try
            {
                Storage.Clients.RemoveAt(clientId);
            }catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        [HttpGet("client{clientId}/getAllCars")]
        public List<Car> GetAllCars(int clientId)
        {
            return Storage.Clients[clientId].Cars;
        }
        [HttpGet("client{clientId}/getAllOrders")]
        public List<Order> GetAllOrders(int clientId)
        {
            return Storage.Clients[clientId].Orders;
        }
    }
}
