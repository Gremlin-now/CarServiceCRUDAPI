using Microsoft.AspNetCore.Mvc;

namespace CarServiceCRUDAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
