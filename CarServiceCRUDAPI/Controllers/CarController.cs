using Microsoft.AspNetCore.Mvc;

namespace CarServiceCRUDAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CarController : Controller
    {
   
        private static List<Car> cars = new List<Car>();

        [HttpGet("cars/{id}")]
        public Car get(int id)
        {
            try
            {
                Response.StatusCode = 200;
                return cars[id];
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Response.StatusCode = 404;
                return new Car("", "", 2001, "aa000a");
            }
        }
        [HttpGet("cars")]
        public List<Car> getCars()
        {
            return cars;
        }
        [HttpPost]
        [ActionName("addCarInList")]
        public void post(Car car)
        {
            Response.StatusCode = 204;
            if (ModelState.IsValid)
            {
                cars.Add(car);
            }
        }
        [HttpPut]
        [ActionName("updateCarInList")]
        public Car put(int id, Car car)
        {
            try
            {
                Response.StatusCode = 200;
                cars[id] = car;
            }
            catch
            {
                Response.StatusCode = 404;
            }
            return car;
        }
        [HttpDelete]
        [ActionName("deleteCarFromList")]
        public void delete(int id) {
            try
            {
                Response.StatusCode = 204;
                cars.RemoveAt(id);
            }
            catch
            {
                Response.StatusCode = 404;
            }
        }
    }
}
