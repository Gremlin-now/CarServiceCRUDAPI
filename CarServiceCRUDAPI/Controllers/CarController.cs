using CarServiceCRUDAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarServiceCRUDAPI.Controllers
{
    [ApiController]
    [Route("api/cars")]
    public class CarController : Controller
    {
        [HttpGet("{carId}")]
        public ActionResult Get(int carId)
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
        [HttpPost("add")]
        public ActionResult Post(Car car)
        {
            Storage.Cars[Storage.LastCarsKey++] = car;
            return Ok(car);
        }
        [HttpPut("update/car{carId}")]
        public ActionResult Put(int carId, Car car)
        {
            try
            {
                Storage.Cars[carId] = car;
                return Ok(car);
            }
            catch
            {
                return BadRequest("Машина не найдена!");
            }
        }
        [HttpDelete("delete/car{carId}")]
        public ActionResult Delete(int carId) {
            try
            {
                Car? car = null;
                Storage.Cars.Remove(carId, out car);
                return Ok(car);
            }
            catch
            {
                return BadRequest("Машина не найдена!");
            }
        }
    }
}
