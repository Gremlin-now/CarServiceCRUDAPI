using Microsoft.AspNetCore.Mvc;

namespace CarServiceCRUDAPI.Controllers
{
    [ApiController]
    [Route("api/")]
    public class CarController : Controller
    {
        [HttpGet("client{clientId}/car{carId}")]
        public Car get(int clientId, int carId)
        {
            try
            {
                Response.StatusCode = 200;
                return Storage.Clients[clientId].Cars[carId];
            }
            catch
            {
                Response.StatusCode = 404;
                return new Car("", "", 2001, "aa000a");
            }
        }
        [HttpPost("client{clientId}/cars/add")]
        public void post(int clientId, Car car)
        {
            Response.StatusCode = 204;
            if (ModelState.IsValid)
            {
                Storage.Clients[clientId].Cars.Add(car);
            }
        }
        [HttpPut("client{clientId}/cars/update/car{carId}")]
        public Car put(int clientId, int carId, Car car)
        {
            try
            {
                Response.StatusCode = 200;
                Storage.Clients[clientId].Cars[carId] = car;
            }
            catch
            {
                Response.StatusCode = 404;
            }
            return car;
        }
        [HttpDelete("client{clientId}/cars/delete/car{carId}")]
        public void delete(int clientId, int carId) {
            try
            {
                Response.StatusCode = 204;
                Storage.Clients[clientId].Cars.RemoveAt(carId);
            }
            catch
            {
                Response.StatusCode = 404;
            }
        }
    }
}
