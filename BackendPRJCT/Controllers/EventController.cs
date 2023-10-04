using BackendPRJCT.DAL;
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
                .Include(p => p.Categories)
                .Include(p => p.Banner)
                .Include(p => p.Tags)
                .Include(p => p.LatestPosts)
                .FirstOrDefault(x => x.Id == id);
            return View(existResult);
        }
    }
}
