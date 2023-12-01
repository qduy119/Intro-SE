using IntroSEProject.API.ViewModels;
using IntroSEProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace IntroSEProject.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : Controller
    {
        private readonly AppDbContext context;

        public ItemsController(AppDbContext context)
        {
            this.context = context;
        }
        [HttpGet]

        public ActionResult GetAll()
        {
            var items = context.Items.ToList();
            if (items == null || items.Count <= 0)
            {
                return NotFound();
            }

            return Ok(items);
        }


        [HttpGet("{id}")]
        
        public ActionResult GetById(int id)
        {
            var item = context.Items.Find(id);
            if (item  == null)
            {
                return BadRequest();
            }

            var model = new ItemViewModel()
            {
                Id = item.Id,
                Thumbnail = item.Thumbnail,
                Name = item.Name,
                Description = item.Description,
                Price = item.Price,
                Discount = item.Discount,
                Stock = item.Stock,
            };

            return Ok(model);
        }

        [HttpPost]

        public ActionResult Create(ItemViewModel item)
        {
            if (ModelState.IsValid)
            {
                var newItem = new Item()
                {
                    Id = item.Id,
                    Thumbnail = item.Thumbnail,
                    Name = item.Name,
                    Description = item.Description,
                    Price = item.Price,
                    Discount = item.Discount,
                    Stock = item.Stock,
                };

                context.Items.Add(newItem);
                context.SaveChanges();

                return Ok();
            }
            return BadRequest();
        }
    }
}
