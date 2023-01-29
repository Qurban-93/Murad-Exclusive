using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BlogsController : Controller
    {
        WebApplicationContext _context;
        public BlogsController(WebApplicationContext context) 
        { _context = context; }  
        public IActionResult Index()
        {
            List<Blog> blogs = _context.Blogs.ToList();  
            
            return View(model:blogs);
        }

        public IActionResult Details(int? id)
        {
            if (id ==null || id == 0)
            {
                return NotFound();
            }
            Blog blogs = _context.Blogs.Include(x=>x.Comments).FirstOrDefault(x=>x.Id==id);
            if (blogs == null) return NotFound();
            return View(model: blogs);
        }
    }
}
