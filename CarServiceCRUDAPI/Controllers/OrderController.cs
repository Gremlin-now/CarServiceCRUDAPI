using Microsoft.AspNetCore.Mvc;

namespace CarServiceCRUDAPI.Controllers
{
    [ApiController]
    [Route("api/")]
    public class OrderController : Controller
    {
        [HttpGet("client{clientId}/order{orderId}")]
        public Order GetOrder(int clientId, int orderId) {
            try
            {
                return Storage.Clients[clientId].Orders[orderId];
            }catch (Exception ex) { 
                Console.WriteLine(ex.Message);
                return new Order();
            }
        }
        [HttpPost("client{clientId}/orders/add")]
        public void PostOrder(int clientId, Order order)
        {
            Storage.Clients[clientId].Orders.Add(order);
        }
        [HttpPut("client{clientId}/orders/update/order{orderId}")]
        public void UpdateOrder(int clientId, int orderId, Order order)
        {
            Storage.Clients[clientId].Orders[orderId] = order;
        }
        [HttpPut("client{clientId}/orders/delete/order{orderId}")]
        public void DeleteOrder(int clientId, int orderId, Order order)
        {
            Storage.Clients[clientId].Orders.RemoveAt(orderId);
        }
    }
}
