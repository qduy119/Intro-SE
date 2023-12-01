using IntroSEProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace IntroSEProject.API.Controllers
{
    public class Obj
    {
        public int status;
        public Obj(int status)
        {
            this.status = status;
        }   
    }

    public class ItemController : Controller
    {
        private readonly AppDbContext context;

        public ItemController(AppDbContext _context)
        {
            this.context = _context;
        }

        [HttpGet]
        public ActionResult Index(int? id)
        {
            Console.WriteLine("/Item/Index");
            return Json(
                new
                {
                    key1 = "dang tuan anh",
                    key2 = id != null ? id.ToString() : "null"
                }
            ); ;
        }
        [HttpGet]
        
        public ActionResult GetItemById(int? id)
        {
            Console.WriteLine("Item/GetItembyid");
            if (id  == null)
            {
                return Json(new { status = 404});
            }
            else
            {
                var data = (from i in this.context.Item
                            where i.Id == id
                            join ci in this.context.CategoryItem
                            on i.Id equals ci.ItemId
                            join c in this.context.Category
                            on ci.CategoryId equals c.Id
                            select new
                            {
                                IdSanPham = i.Id,
                                tensanpham = i.Name,
                                MotaSanPham = i.Description,
                                tenCategory = c.Name,
                                IdCategory = c.Id
                            })
                            .FirstOrDefault();
                if(data == null)
                {
                    return Json(new {status = 404});
                }
                else
                {
                    return Json(new
                    {
                        status = 200,
                        data = data
                    });
                }
            }
        }
    }
}
