using BackendPRJCT.DAL;
using BackendPRJCT.ModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

            BlogDetailVM vm = new();
            vm.Banner = _appDbContext.Banners.FirstOrDefault();
            vm.Categories = _appDbContext.Categories.ToList();
            vm.LatestPosts = _appDbContext.LatestPosts.ToList();
            vm.Tags = _appDbContext.Tags.ToList();
            vm.Blog = existResult;
            return View(vm);

        }
    }
}
