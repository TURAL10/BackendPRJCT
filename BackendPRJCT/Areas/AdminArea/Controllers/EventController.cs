using BackendPRJCT.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendPRJCT.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class EventController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public EventController(AppDbContext context)
        {
            _appDbContext = context;
        }
        public IActionResult Index()
        {
            var existResult = _appDbContext.Events.ToList();
            return View(existResult);
        }
    }
}
