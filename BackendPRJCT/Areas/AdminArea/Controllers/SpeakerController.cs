using BackendPRJCT.DAL;
using BackendPRJCT.Models;
using BackendPRJCT.ModelViews.AdminEvent;
using BackendPRJCT.ModelViews.AdminSpeaker;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BackendPRJCT.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class SpeakerController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SpeakerController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _appDbContext = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var existResult = _appDbContext.Speakers
                .ToList();
            return View(existResult);
        }
        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();
            var existResult = _appDbContext.Speakers
                .FirstOrDefault(c => c.Id == id);
            if (existResult == null) return NotFound();
            return View(existResult);
        }
        public IActionResult Create()
        {
            ViewBag.Events = _appDbContext.Events.ToList();
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(CreateSpeakerVM createSpeakerVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (_appDbContext.Speakers.Any(t => t.Name == createSpeakerVM.Name))
            {
                ModelState.AddModelError("Name", "This Name doesn't exits");
            }
            ViewBag.Speakers = _appDbContext.Speakers.ToList();
            Speaker speaker = new();
            speaker.Name = createSpeakerVM.Name;
            speaker.Prof = createSpeakerVM.Prof;
            string filename = Guid.NewGuid() + createSpeakerVM.Image.FileName;
            string path = Path.Combine(_webHostEnvironment.WebRootPath, "img/event", filename);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                createSpeakerVM.Image.CopyTo(stream);
            }
            speaker.Image = filename;

            foreach (var speakerId in createSpeakerVM.EventId)
            {
                Speaker eventSpeaker = new();
                eventSpeaker = speaker;
                eventSpeaker.EventId = speakerId;

            }

            _appDbContext.Speakers.Add(speaker);
            _appDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Update(int? id)
        {
            if (id == null) return NotFound();
            var existResult = _appDbContext.Speakers
                .FirstOrDefault(i => i.Id == id);
            if (existResult == null) return NotFound();
            var updateSlider = new UpdateSpeaker
            {
                Id = existResult.Id,
                Name = existResult.Name,
                Prof = existResult.Prof,
                Events = _appDbContext.Events.ToList(),
            };
            return View(updateSlider);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(UpdateSpeaker updateSpeaker)
        {
            if (!ModelState.IsValid) return View();
            var existResult = _appDbContext.Speakers.FirstOrDefault(i => i.Id == updateSpeaker.Id);

            if (_appDbContext.Speakers.Any(c => c.Name == updateSpeaker.Name && c.Id != existResult.Id))
            {
                ModelState.AddModelError("Name", "artiq movcutdur");
                return View();
            }

            existResult.Name = updateSpeaker.Name;
            existResult.Prof = updateSpeaker.Prof;

            string filename = Guid.NewGuid() + updateSpeaker.Image.FileName;
            string path = Path.Combine(_webHostEnvironment.WebRootPath, "img/event", filename);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                updateSpeaker.Image.CopyTo(stream);
            }
            existResult.Image = filename;

            foreach (var speakerId in updateSpeaker.EventId)
            {
                Speaker eventSpeaker = new();
                eventSpeaker.EventId = speakerId;
            }

            _appDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            if (id == 0) return NotFound();
            var deletedSpeaker = _appDbContext.Speakers.FirstOrDefault(c => c.Id == id);
            if (deletedSpeaker == null) return NotFound();
            _appDbContext.Speakers.Remove(deletedSpeaker);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
