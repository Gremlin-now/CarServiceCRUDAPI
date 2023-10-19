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
                Response.StatusCode = 200;
                return Storage.Clients[clientId].Orders[orderId];
            }catch {
                Response.StatusCode = 404;
                return new Order();
            }
        }
        [HttpPost("client{clientId}/orders/add/car{carId}")]
        public void PostOrder(int clientId, int carId, string description, string status)
        {
            try
            {
                Response.StatusCode = 204;
                Storage.Clients[clientId].Orders.Add(new Order
                {
                    car = Storage.Clients[clientId].Cars[carId],
                    Date = DateTime.Now.ToLongDateString(),
                    Description = description,
                    Status = status
                });
            }catch {
                Response.StatusCode = 404;
            }
        }
        [HttpPut("client{clientId}/orders/update/order{orderId}")]
        public void UpdateOrder(int clientId, int orderId, Order order)
        {
            try
            {
                Response.StatusCode = 204;
                Storage.Clients[clientId].Orders[orderId] = order;
            }
            catch
            {
                Response.StatusCode = 404;
            }
        }
        [HttpPut("client{clientId}/orders/delete/order{orderId}")]
        public void DeleteOrder(int clientId, int orderId, Order order)
        {
            try
            {
                Response.StatusCode = 204;
                Storage.Clients[clientId].Orders.RemoveAt(orderId);
            }
            catch
            {
                Response.StatusCode = 404;
            }
        }
    }
}
