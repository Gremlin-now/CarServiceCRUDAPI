using Microsoft.AspNetCore.Mvc;

namespace CarServiceCRUDAPI.Controllers
{
    [ApiController]
    [Route("api/")]
    public class CarController : Controller
    {
        [HttpGet("client{clientId}/car{carId}")]
        public ActionResult get(int clientId, int carId)
        {
            try
            {
                return Ok(Storage.Clients[clientId].Cars[carId]);
            }
            catch
            {
                return BadRequest("Клиент или машина не найдены!");
            }
        }
        [HttpPost("client{clientId}/cars/add")]
        public ActionResult post(int clientId, Car car)
        {
            try
            {
                Storage.Clients[clientId].Cars.Add(car);
                return Ok("Машина успешно добавлена!");
            }
            catch
            {
                return BadRequest("Клиент не найден!");
            }
        }
        [HttpPut("client{clientId}/cars/update/car{carId}")]
        public ActionResult put(int clientId, int carId, Car car)
        {
            try
            {
                Storage.Clients[clientId].Cars[carId] = car;
                return Ok("Данные о машине успешно обновлены");
            }
            catch
            {
                return BadRequest("Клиент или машина не найдены!");
            }
        }
        [HttpDelete("client{clientId}/cars/delete/car{carId}")]
        public ActionResult delete(int clientId, int carId) {
            try
            {
                Storage.Clients[clientId].Cars.RemoveAt(carId);
                return Ok("Данные о машине успешно удалены!");
            }
            catch
            {
                return BadRequest("Клиент или машина не найдены!");
            }
        }
    }
}
