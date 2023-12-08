using AutoMapper;
using IntroSEProject.API.Models;
using IntroSEProject.API.Services;
using IntroSEProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntroSEProject.API.Controllers
{
    [Authorize(Roles = "Customer, Admin")]
    [ApiController]
    [Route("/api/[controller]")]
    public class CategoriesController : ControllerBase
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

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Edit(int id, CategoryModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }
            var category = mapper.Map<Category>(model);
            var foundCategory = dbContext.Categories.Find(id);
            if (foundCategory == null)
            {
                return NotFound();
            }
            dbContext.Entry(foundCategory).CurrentValues.SetValues(category);
            try
            {
                await dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!dbContext.Categories.Any(e => e.Id == id))
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
            var category = dbContext.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            dbContext.Categories.Remove(category);
            await dbContext.SaveChangesAsync();
            return Ok(category.Name);
        }
    }
}
