using Microsoft.AspNetCore.Mvc;

namespace IntroSEProject.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CheckoutController : ControllerBase
    {
        [HttpPost("/checkout")]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
