using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IntroSEProject.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok("Get all categories");
        }
    }
}
