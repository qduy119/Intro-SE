using AutoMapper;
using IntroSEProject.API.Models;
using IntroSEProject.API.Services;
using IntroSEProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Linq.Expressions;

namespace IntroSEProject.API.Controllers
{
    //[Authorize(Roles = "Customer, Admin")]
    [ApiController]
    [Route("/api/[controller]")]
    public class ItemsController : Controller
    {
        private AppDbContext dbContext;
        private IMapper mapper;

        public ItemsController(AppDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetPaging(int page = 1, int per_page = 0, string keyword = "", int categoryId = 0)
        {
            IEnumerable<Item> list;
            if (categoryId != 0)
            {
                list = dbContext.Items.Where(item => item.CategoryId == categoryId).ToList();
            }
            else if (string.IsNullOrEmpty(keyword))
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


        [HttpGet("top5")]
        public async Task<IActionResult> GetTopItem()
        {
            var result = await dbContext.OrderItems.GroupBy(x => x.ItemId)
                .Select(group => new
                {
                    Item = mapper.Map<ItemModel>(dbContext.Items.Where(i => i.Id == group.Key).SingleOrDefault()),
                    SoldQuantity = group.Sum(x => x.Quantity)
                }).OrderByDescending(x => x.SoldQuantity)
                .Take(5).ToListAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await dbContext.Items.FindAsync(id);
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
            await Console.Out.WriteLineAsync("======================================");
            await Console.Out.WriteLineAsync(model.Name);
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

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] ItemModel model)
        {
            var item = await dbContext.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            model.Id = id;
            mapper.Map(model, item);
            try
            {
                await dbContext.SaveChangesAsync();
                return Ok(model);
            }
            catch (DbUpdateConcurrencyException)
                {
                    if (!dbContext.Items.Any(e => e.Id == model.Id))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return Ok(model);
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                var item = await dbContext.Items.FindAsync(id);
                if (item == null)
                {
                    return NotFound();
                }
                var model = mapper.Map<ItemModel>(item);
                dbContext.Items.Remove(item);
                await dbContext.SaveChangesAsync();
                return Ok(model);
            }

        [HttpGet("top5sell")]
        public async Task<IActionResult> GetTop5SellItems()
        {
            var result = await dbContext.OrderItems.GroupBy(x => x.ItemId)
                .Select(group => new
                {
                    Item = mapper.Map<ItemModel>(dbContext.Items.Where(i => i.Id == group.Key).SingleOrDefault()),
                    SoldQuantity = group.Sum(x => x.Quantity)
                }).OrderByDescending(x => x.SoldQuantity)
                .Take(5).ToListAsync();
            return Ok(result);  
        }
    }
    }
