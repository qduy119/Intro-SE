using AutoMapper;
using IntroSEProject.API.Models;
using IntroSEProject.API.Services;
using IntroSEProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntroSEProject.API.Controllers
{
    //[Authorize(Roles = "Customer, Admin")]
    [ApiController]
    [Route("/api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private AppDbContext dbContext;
        private IMapper mapper;

        public ItemsController(AppDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetPaging(int page = 1, int per_page = 0, string keyword = "")
        {
            
            IEnumerable<Item> list;
            if (string.IsNullOrEmpty(keyword))
            {
                list = await dbContext.Items.ToListAsync();
            }
            else
            {
                list = await dbContext.Items.Where(x => x.Name.Contains(keyword)).ToListAsync();
            }
            if (per_page == 0)
            {
                per_page = list.Count();
            }
            var model = mapper.Map<IEnumerable<ItemModel>>(list);
            var pager = new Pager<ItemModel>(model, page, per_page);
            return Ok(pager);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = dbContext.Items.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            var model = mapper.Map<ItemModel>(item);
            return Ok(model);
        }


        [HttpPost]
        public async Task<IActionResult> Create(ItemModel model)
        {
            var category = await dbContext.Categories.FindAsync(model.CategoryId);
            if (category == null)
            {
                return BadRequest(new { error = $"Category with id {model.CategoryId} does not exist" });
            }
            var item = mapper.Map<Item>(model);
            try
            {
                await dbContext.Items.AddAsync(item);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest();
            }
            model.Id = item.Id;
            return Ok(model);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Edit(int id, ItemModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }
            var category = await dbContext.Categories.FindAsync(model.CategoryId);
            if (category == null)
            {
                return BadRequest(new { error = $"Category with id {model.CategoryId} does not exist" });
            }
            var item = mapper.Map<Item>(model);
            var foundItem = dbContext.Items.Find(id);
            if (foundItem == null)
            {
                return NotFound();
            }
            dbContext.Entry(foundItem).CurrentValues.SetValues(item);
            try
            {
                await dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!dbContext.Items.Any(e => e.Id == id))
                {
                    return NotFound();
                }    
                throw;
            }
            return Ok(model);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = dbContext.Items.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            dbContext.Items.Remove(item);
            await dbContext.SaveChangesAsync();
            return Ok(item.Name);
        }
    }
}
