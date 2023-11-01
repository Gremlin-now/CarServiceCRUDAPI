using CarServiceCRUDAPI.Models;
using CarServiceCRUDAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CarServiceCRUDAPI.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrderController : Controller
    {
        IOrderRepository orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }
        [HttpGet("{orderId}")]
        public ActionResult GetOrder(int orderId) {
            return Ok(orderRepository.Get(orderId));
        }
        [HttpGet("clients/{clientId}")]
        public ActionResult GetOrderByClientID(int clientId)
        {
            return Ok(orderRepository.GetAllbyClientID(clientId));
        }
        [HttpPost("add")]
        public ActionResult PostOrder(int clientId, int carId, string? description)
        {
            return Ok(orderRepository.Create(new Order { ClientID = clientId, CarID = carId, Description = description, Status = "Создано" }));
        }
        [HttpPut("update/order{orderId}")]
        public ActionResult UpdateOrder(int orderId, Order order)
        {
            return Ok(orderRepository.Update(order, orderId));
        }
        [HttpPut("delete/order{orderId}")]
        public ActionResult DeleteOrder(int orderId)
        {
            return Ok(orderRepository.Delete(orderId));
        }
    }
}
