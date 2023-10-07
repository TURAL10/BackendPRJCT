using BackendPRJCT.DAL;
using BackendPRJCT.Models;
using BackendPRJCT.ModelViews.AdminEvent;
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
            var existResult = _appDbContext.Events
                .ToList();
            return View(existResult);
        }
        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();
            var existResult = _appDbContext.Events
                .FirstOrDefault(c => c.Id == id);
            if (existResult == null) return NotFound();
            return View(existResult);
        }
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(CreateEventVM createEventVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (_appDbContext.Events.Any(t => t.Title == createEventVM.Title))
            {
                ModelState.AddModelError("Title", "This title doesn't exits");
            }
            Event events = new();
            events.Image = createEventVM.Image;
            events.Title = createEventVM.Title;
            events.Description = createEventVM.Description;
            events.Time = createEventVM.Time;
            events.Venue = createEventVM.Venue;
            events.City = createEventVM.City;
            events.Day = createEventVM.Day;
            events.Month = createEventVM.Month;
            _appDbContext.Events.Add(events);
            _appDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Update(int? id)
        {
            if (id == null) return NotFound();
            var existResult = _appDbContext.Events.FirstOrDefault(i => i.Id == id);
            if (existResult == null) return NotFound();
            var updateeventVM = new UpdateEventVM
            {
                Id = existResult.Id,
                Image = existResult.Image,
                Title = existResult.Title,
                Description = existResult.Description,
                Month = existResult.Month,
                Day = existResult.Day,
                Time = existResult.Time,
                Venue = existResult.Venue,
                City = existResult.City,
            };
            return View(updateeventVM);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(UpdateEventVM updateEventVM)
        {
            if (!ModelState.IsValid) return View();
            var existResult = _appDbContext.Events.FirstOrDefault(i => i.Id == updateEventVM.Id);

            if (_appDbContext.Events.Any(c => c.Title == updateEventVM.Title && c.Id != existResult.Id))
            {
                ModelState.AddModelError("Title", "artiq movcutdur");
                return View();
            }

            existResult.Image = updateEventVM.Image;
            existResult.Title = updateEventVM.Title;
            existResult.Description = updateEventVM.Description;
            existResult.Month = updateEventVM.Month;
            existResult.Day = updateEventVM.Day;
            existResult.Time = updateEventVM.Time;
            existResult.Venue = updateEventVM.Venue;
            existResult.City = updateEventVM.City;

            _appDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            if (id == 0) return NotFound();
            var deletedEvent = _appDbContext.Events.FirstOrDefault(c => c.Id == id);
            if (deletedEvent == null) return NotFound();
            _appDbContext.Events.Remove(deletedEvent);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
