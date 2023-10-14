using BackendPRJCT.DAL;
using BackendPRJCT.Models;
using BackendPRJCT.ModelViews.AdminBlog;
using BackendPRJCT.ModelViews.AdminSlider;
using BackendPRJCT.ModelViews.AdminSpeaker;
using Microsoft.AspNetCore.Mvc;

namespace BackendPRJCT.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class SliderController : Controller
    {

        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SliderController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _appDbContext = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var existResult = _appDbContext.Sliders
                .ToList();
            return View(existResult);
        }
        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();
            var existResult = _appDbContext.Sliders
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
        public IActionResult Create(CreateSlider createSlider)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (_appDbContext.Sliders.Any(t => t.Title == createSlider.Title))
            {
                ModelState.AddModelError("Title", "This title doesn't exits");
            }
            Slider slider = new();
            slider.Title = createSlider.Title;
            slider.Desc = createSlider.Desc;
            string filename = Guid.NewGuid() + createSlider.Image.FileName;
            string path = Path.Combine(_webHostEnvironment.WebRootPath, "img/slider", filename);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                createSlider.Image.CopyTo(stream);
            }
            slider.Image = filename;
            _appDbContext.Sliders.Add(slider);
            _appDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Update(int? id)
        {
            if (id == null) return NotFound();
            var existResult = _appDbContext.Sliders.FirstOrDefault(i => i.Id == id);
            if (existResult == null) return NotFound();
            var updateSlider = new UpdateSlider
            {
                Id = existResult.Id,
                Title = existResult.Title,
                Desc = existResult.Desc,
            };
            return View(updateSlider);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(UpdateSlider updateSlider)
        {
            if (!ModelState.IsValid) return View();
            var existResult = _appDbContext.Sliders.FirstOrDefault(i => i.Id == updateSlider.Id);

            if (_appDbContext.Sliders.Any(c => c.Title == updateSlider.Title && c.Id != existResult.Id))
            {
                ModelState.AddModelError("Title", "artiq movcutdur");
                return View();
            }

            existResult.Title = updateSlider.Title;
            existResult.Desc = updateSlider.Desc;
            if (updateSlider.Image != null)
            {

                if (!updateSlider.Image.ContentType.Contains("image/"))
                {
                    ModelState.AddModelError("Photo", "only image");
                    return View();
                }
                if (updateSlider.Image.Length / 1024 > 1000)
                {
                    ModelState.AddModelError("Photo", "Size is High");
                    return View();
                }
                string filename = Guid.NewGuid() + updateSlider.Image.FileName;
                string path = Path.Combine(_webHostEnvironment.WebRootPath, "img/slider", filename);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    updateSlider.Image.CopyTo(stream);
                }
                existResult.Image = filename;
            }

            _appDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            if (id == 0) return NotFound();
            var deletedSlider = _appDbContext.Sliders.FirstOrDefault(c => c.Id == id);
            if (deletedSlider == null) return NotFound();
            _appDbContext.Sliders.Remove(deletedSlider);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
