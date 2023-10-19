using Microsoft.AspNetCore.Mvc;

namespace CarServiceCRUDAPI.Controllers
{
    [ApiController]
    [Route("api/")]
    public class CarController : Controller
    {
        [HttpGet("car{carId}")]
        public ActionResult get(int carId)
        {
            try
            {
                return Ok(Storage.Cars[carId]);
            }
            catch
            {
                return BadRequest("Машина не найдена!");
            }
        }
        [HttpPost("cars/add")]
        public ActionResult post(Car car)
        {
            Storage.Cars[Storage.LastCarsKey++] = car;
            return Ok("Машина успешно добавлена!");
        }
        [HttpPut("cars/update/car{carId}")]
        public ActionResult put(int carId, Car car)
        {
            try
            {
                Storage.Cars[carId] = car;
                return Ok("Данные о машине успешно обновлены");
            }
            catch
            {
                return BadRequest("Машина не найдена!");
            }
        }
        [HttpDelete("cars/delete/car{carId}")]
        public ActionResult delete(int carId) {
            try
            {
                Storage.Cars.Remove(carId);
                return Ok("Данные о машине успешно удалены!");
            }
            catch
            {
                return BadRequest("Машина не найдена!");
            }
        }
    }
}
