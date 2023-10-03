using BackendPRJCT.DAL;
using Microsoft.AspNetCore.Mvc;

namespace BackendPRJCT.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public BlogController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            var existResult = _appDbContext.Blogs.ToList();
            return View(existResult);
        }
        public IActionResult Details(int? id)
        {
            var existResult = _appDbContext.Blogs.FirstOrDefault(x => x.Id == id);
            return View(existResult);
        }
    }
}
