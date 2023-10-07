using BackendPRJCT.DAL;
using BackendPRJCT.ModelViews;
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
                .FirstOrDefault(x => x.Id == id);

            CourseDetailVM vm = new();
            vm.Banner = _appDbContext.Banners.FirstOrDefault();
            vm.Categories = _appDbContext.Categories.ToList();
            vm.LatestPosts = _appDbContext.LatestPosts.ToList();
            vm.Tags = _appDbContext.Tags.ToList();
            vm.Course = existResult;
            return View(vm);
        }
    }
}
