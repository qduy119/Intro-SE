using AutoMapper;
using IntroSEProject.API.Models;
using IntroSEProject.API.Services;
using IntroSEProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntroSEProject.API.Controllers
{
    //[Authorize(Roles = "Customer, Admin")]
    [ApiController]
    [Route("/api/[controller]")]
    public class CategoriesController : Controller
    {
        private AppDbContext dbContext;
        private IMapper mapper;

        public CategoriesController(AppDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetPaging(int page = 1, int per_page = 0, string keyword = "")
        {
            
            IEnumerable<Category> list;
            if (string.IsNullOrEmpty(keyword))
            {
                list = await dbContext.Categories.ToListAsync();
            }
            else
            {
                list = await dbContext.Categories.Where(x => x.Name.Contains(keyword)).ToListAsync();
            }
            if (per_page == 0)
            {
                per_page = list.Count();
            }
            var model = mapper.Map<IEnumerable<CategoryModel>>(list);
            var pager = new Pager<CategoryModel>(model, page, per_page);
            return Ok(pager);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await dbContext.Categories.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            var model = mapper.Map<CategoryModel>(item);
            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryModel model)
        {
            var category = mapper.Map<Category>(model);
            try
            {
                await dbContext.Categories.AddAsync(category);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest();
            }
            model.Id = category.Id;
            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] CategoryModel model)
        {
            var category = await dbContext.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            model.Id = id;
            mapper.Map(model, category);
            try
            {
                await dbContext.SaveChangesAsync();
                return Ok(model);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!dbContext.Categories.Any(x => x.Id == id))
                if (!dbContext.Categories.Any(e => e.Id == model.Id))
                {
                    return NotFound();
                }    
                throw;
            }
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await dbContext.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            var model = mapper.Map<CategoryModel>(category);
            dbContext.Categories.Remove(category);
            await dbContext.SaveChangesAsync();
            return Ok(model);
        }
    }
}
