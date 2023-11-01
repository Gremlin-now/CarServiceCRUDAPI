using CarServiceCRUDAPI.Models;
using CarServiceCRUDAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CarServiceCRUDAPI.Controllers
{
    [ApiController]
    [Route("api/cars")]
    public class CarController : Controller
    {

        IBaseRepository<Car> carRepository;

        public CarController(IBaseRepository<Car> carRepository)
        {
            this.carRepository = carRepository;
        }

        [HttpGet("{carId}")]
        public ActionResult Get(int carId)
        {
                return Ok(carRepository.Get(carId));
        }
        [HttpPost("add")]
        public ActionResult Post(Car car)
        {
            return Ok(carRepository.Create(car));
        }
        [HttpPut("update/car{carId}")]
        public ActionResult Put(int carId, Car car)
        {
            return Ok(carRepository.Update(car, carId));
        }
        [HttpDelete("delete/car{carId}")]
        public ActionResult Delete(int carId) {
            return Ok(carRepository.Delete(carId));
        }
    }
}
