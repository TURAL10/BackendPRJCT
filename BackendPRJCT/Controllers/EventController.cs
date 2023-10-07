using BackendPRJCT.DAL;
using BackendPRJCT.ModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendPRJCT.Controllers
{
    public class EventController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public EventController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            var existResult = _appDbContext.Events.ToList();
            return View(existResult);
        }
        public IActionResult Details(int? id)
        {
            var existResult = _appDbContext.Events
                .Include(p=>p.Speakers)
                .FirstOrDefault(x => x.Id == id);

            EventDetailVM vm = new();
            vm.Banner = _appDbContext.Banners.FirstOrDefault();
            vm.Categories = _appDbContext.Categories.ToList();
            vm.LatestPosts = _appDbContext.LatestPosts.ToList();
            vm.Tags = _appDbContext.Tags.ToList();
            vm.Event = existResult;
            return View(vm);
        }
    }
}
