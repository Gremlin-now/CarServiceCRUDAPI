using CarServiceCRUDAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarServiceCRUDAPI.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrderController : Controller
    {
        [HttpGet("{orderId}")]
        public ActionResult GetOrder(int clientId, int orderId) {
            try
            {
                return Ok(Storage.Orders[orderId]);
            }catch {
                return BadRequest("Не найден клиент или заказ!");
            }
        }
        [HttpPost("add")]
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
                return Ok(Storage.Orders[Storage.LastOrdersKey]);
            }catch {
                return BadRequest("Не найден клиент или авто!");
            }
        }
        [HttpPut("update/order{orderId}")]
        public ActionResult UpdateOrder(int orderId, Order order)
        {
            try
            {
                
                Storage.Orders[orderId] = order;
                return Ok(order);
            }
            catch
            {
                return BadRequest("Не найден заказ!");
            }
        }
        [HttpPut("delete/order{orderId}")]
        public ActionResult DeleteOrder(int orderId)
        {
            try
            {
                Order? order = null;
                Storage.Orders.Remove(orderId, out order);
                return Ok(order);
            }
            catch
            {
                return BadRequest("Не найден заказ!");
            }
        }
    }
}
