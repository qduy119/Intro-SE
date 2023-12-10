using AutoMapper;
using IntroSEProject.API.Models;
using IntroSEProject.API.Services;
using IntroSEProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntroSEProject.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CartItemController : Controller
    {
        private AppDbContext dbContext;
        private IMapper mapper;
        public CartItemController(AppDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetPaging(int page = 1, int per_page = 0)
        {
            IEnumerable<CartItem> list;
            list = (IEnumerable<CartItem>)await dbContext.CartItems.ToListAsync();
            if (per_page == 0)
            {
                per_page = list.Count();
            }
            var model = mapper.Map<IEnumerable<CartItemModel>>(list);
            var pager = new Pager<CartItemModel>(model, page, per_page);
            return Ok(pager);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await dbContext.CartItems.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            var model = mapper.Map<CartItemModel>(order);
            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CartItemModel model)
        {
            var user = await dbContext.Users.FindAsync(model.UserId);
            if (user == null)
            {
                return BadRequest(new { error = $"User with id {model.UserId} does not exist" });
            }
            var item = await dbContext.Items.FindAsync(model.ItemId);
            if(item == null)
            {
                return BadRequest(new {error = $"Item has id = {model.ItemId} not exist" });
            }
            var order = mapper.Map<CartItem>(model);
            try
            {
                await dbContext.CartItems.AddAsync(order);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest();
            }
            model.Id = order.Id;
            return Ok(model);
        }

        [HttpPut]
        public async Task<IActionResult> Edit(CartItemModel model)
        {
            var user = await dbContext.Users.FindAsync(model.UserId);
            if (user == null)
            {
                return BadRequest(new { error = $"Category with id {model.UserId} does not exist" });
            }
            var item = await dbContext.Items.FindAsync(model.ItemId);
            if (item == null)
            {
                return BadRequest(new { error = $"Item has id = {model.ItemId} not exist" });
            }
            var order = mapper.Map<CartItem>(model);
            var foundCartItem = dbContext.CartItems.Find(model.Id);
            if (foundCartItem == null)
            {
                return NotFound();
            }
            dbContext.Entry(foundCartItem).CurrentValues.SetValues(order);
            try
            {
                await dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!dbContext.CartItems.Any(e => e.Id == model.Id))
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
            var order = dbContext.CartItems.Find(id);
            if (order == null)
            {
                return NotFound();
            }
            dbContext.CartItems.Remove(order);
            await dbContext.SaveChangesAsync();
            var model = mapper.Map<CartItemModel>(order);
            return Ok(model);
        }
    }
}
