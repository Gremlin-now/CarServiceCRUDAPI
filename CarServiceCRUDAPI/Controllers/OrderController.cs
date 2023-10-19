using Microsoft.AspNetCore.Mvc;

namespace CarServiceCRUDAPI.Controllers
{
    [ApiController]
    [Route("api/")]
    public class OrderController : Controller
    {
        [HttpGet("client{clientId}/order{orderId}")]
        public ActionResult GetOrder(int clientId, int orderId) {
            try
            {
                return Ok(Storage.Clients[clientId].Orders[orderId]);
            }catch {
                return BadRequest("Не найден клиент или заказ!");
            }
        }
        [HttpPost("client{clientId}/orders/add/car{carId}")]
        public ActionResult PostOrder(int clientId, int carId, string description, string status)
        {
            try
            {
                Response.StatusCode = 204;
                Storage.Clients[clientId].Orders.Add(new Order
                {
                    car = Storage.Clients[clientId].Cars[carId],
                    Date = DateTime.Now.ToLongDateString(),
                    Description = description,
                    Status = "Создан"
                });
                return Ok("Заказ успешно создан!");
            }catch {
                return BadRequest("Не найден клиент или авто!");
            }
        }
        [HttpPut("client{clientId}/orders/update/order{orderId}")]
        public ActionResult UpdateOrder(int clientId, int orderId, Order order)
        {
            try
            {
                
                Storage.Clients[clientId].Orders[orderId] = order;
                return Ok("Успешно обновлен!");
            }
            catch
            {
                return BadRequest("Не найден клиент или заказ!");
            }
        }
        [HttpPut("client{clientId}/orders/delete/order{orderId}")]
        public ActionResult DeleteOrder(int clientId, int orderId, Order order)
        {
            try
            {
                Storage.Clients[clientId].Orders.RemoveAt(orderId);
                return Ok("Заказ успешно обновлен!");
            }
            catch
            {
                return BadRequest("Не найден клиент или заказ!");
            }
        }
    }
}
