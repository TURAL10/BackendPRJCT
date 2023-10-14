using BackendPRJCT.DAL;
using BackendPRJCT.Models;
using BackendPRJCT.ModelViews.AdminCourse;
using BackendPRJCT.ModelViews.AdminEvent;
using BackendPRJCT.ModelViews.AdminSpeaker;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendPRJCT.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class EventController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EventController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _appDbContext = context;
            _webHostEnvironment = webHostEnvironment;
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
            events.Title = createEventVM.Title;
            events.Description = createEventVM.Description;
            events.Time = createEventVM.Time;
            events.Venue = createEventVM.Venue;
            events.City = createEventVM.City;
            events.Day = createEventVM.Day;
            events.Month = createEventVM.Month;
            string filename = Guid.NewGuid() + createEventVM.Image.FileName;
            string path = Path.Combine(_webHostEnvironment.WebRootPath, "img/event", filename);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                createEventVM.Image.CopyTo(stream);
            }
            events.Image = filename;
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

            existResult.Title = updateEventVM.Title;
            existResult.Description = updateEventVM.Description;
            existResult.Month = updateEventVM.Month;
            existResult.Day = updateEventVM.Day;
            existResult.Time = updateEventVM.Time;
            existResult.Venue = updateEventVM.Venue;
            existResult.City = updateEventVM.City;
            if (updateEventVM.Image != null)
            {

                if (!updateEventVM.Image.ContentType.Contains("image/"))
                {
                    ModelState.AddModelError("Photo", "only image");
                    return View();
                }
                if (updateEventVM.Image.Length / 1024 > 1000)
                {
                    ModelState.AddModelError("Photo", "Size is High");
                    return View();
                }
                string filename = Guid.NewGuid() + updateEventVM.Image.FileName;
                string path = Path.Combine(_webHostEnvironment.WebRootPath, "img/event", filename);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    updateEventVM.Image.CopyTo(stream);
                }
                existResult.Image = filename;
            }

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
