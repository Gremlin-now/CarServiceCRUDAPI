using Microsoft.AspNetCore.Mvc;

namespace CarServiceCRUDAPI.Controllers
{
    [ApiController]
    [Route("api/")]
    public class OrderController : Controller
    {
        [HttpGet("order{orderId}")]
        public ActionResult GetOrder(int clientId, int orderId) {
            try
            {
                return Ok(Storage.Orders[orderId]);
            }catch {
                return BadRequest("Не найден клиент или заказ!");
            }
        }
        [HttpPost("orders/add")]
        public ActionResult PostOrder(int clientId, int carId, string? description)
        {
            try
            {
                Storage.Orders[Storage.LastOrdersKey++] = new Order
                {
                    CarID = carId,
                    ClientID = clientId,
                    Date = DateTime.Now.ToLongDateString(),
                    Description = description,
                    Status = "Создан"
                };
                return Ok("Заказ успешно создан!");
            }catch {
                return BadRequest("Не найден клиент или авто!");
            }
        }
        [HttpPut("orders/update/order{orderId}")]
        public ActionResult UpdateOrder(int orderId, Order order)
        {
            try
            {
                
                Storage.Orders[orderId] = order;
                return Ok("Успешно обновлен!");
            }
            catch
            {
                return BadRequest("Не найден заказ!");
            }
        }
        [HttpPut("orders/delete/order{orderId}")]
        public ActionResult DeleteOrder(int orderId, Order order)
        {
            try
            {
                Storage.Orders.Remove(orderId);
                return Ok("Заказ успешно удален!");
            }
            catch
            {
                return BadRequest("Не найден заказ!");
            }
        }
    }
}
