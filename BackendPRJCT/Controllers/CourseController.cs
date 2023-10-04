using BackendPRJCT.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendPRJCT.Controllers
{
    public class CourseController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public CourseController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            var existResult = _appDbContext.Courses.ToList();
            return View(existResult);
        }
        public IActionResult Details(int? id)
        {
            var existResult = _appDbContext.Courses
                .Include(p => p.Features)
                .Include(p => p.Categories)
                .Include(p => p.Banner)
                .Include(p => p.Tags)
                .Include(p => p.LatestPosts)
                .FirstOrDefault(x => x.Id == id);
            return View(existResult);
        }
    }
}
