using BackendPRJCT.DAL;
using Microsoft.AspNetCore.Mvc;

namespace BackendPRJCT.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;

        public BlogController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var existResult = _context.Blogs.ToList();
            return View(existResult);
        }
    }
}
