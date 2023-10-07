using BackendPRJCT.DAL;
using Microsoft.AspNetCore.Mvc;
using BackendPRJCT.Helpers;
using BackendPRJCT.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BackendPRJCT.ModelViews.AdminCourse;

namespace BackendPRJCT.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class CourseController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public CourseController(AppDbContext context)
        {
            _appDbContext = context;
        }

        public IActionResult Index()
        {
            var existResult = _appDbContext.Courses
                .ToList();
            return View(existResult);
        }
        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();
            var existResult = _appDbContext.Courses
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
        public IActionResult Create(CreateCourseVM createCourseVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (_appDbContext.Courses.Any(t=>t.Title==createCourseVM.Title))
            {
                ModelState.AddModelError("Title", "This title doesn't exits");
            }
            Course course = new();
            course.Image = createCourseVM.Image;
            course.Title = createCourseVM.Title;
            course.Description = createCourseVM.Description;
            course.About = createCourseVM.About;
            course.Apply = createCourseVM.Apply;
            course.Certification = createCourseVM.Certification;
            _appDbContext.Courses.Add(course);
            _appDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Update(int? id)
        {
            if (id == null) return NotFound();
            var existResult = _appDbContext.Courses.FirstOrDefault(i=> i.Id==id);
            if (existResult == null) return NotFound();
            var updateCourseVM = new UpdateCourseVM
            {
                Id = existResult.Id,
                Image = existResult.Image,
                Title = existResult.Title,
                Description = existResult.Description,
                About = existResult.About,
                Apply = existResult.Apply,
                Certification = existResult.Certification,
            };
            return View(updateCourseVM);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(UpdateCourseVM updateCourseVM)
        {
            if (!ModelState.IsValid) return View();
            var existResult = _appDbContext.Courses.FirstOrDefault(i => i.Id == updateCourseVM.Id);

            if (_appDbContext.Courses.Any(c => c.Title == updateCourseVM.Title && c.Id != existResult.Id)) 
            {
                ModelState.AddModelError("Title", "artiq movcutdur");
                return View();
            }

            existResult.Image = updateCourseVM.Image;
            existResult.Title = updateCourseVM.Title;
            existResult.Description = updateCourseVM.Description;
            existResult.About = updateCourseVM.About;
            existResult.Apply = updateCourseVM.Apply;
            existResult.Certification = updateCourseVM.Certification;
            _appDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            if (id == 0) return NotFound();
            var deletedCourse=_appDbContext.Courses.FirstOrDefault(c => c.Id == id);
            if (deletedCourse == null) return NotFound();
            _appDbContext.Courses.Remove(deletedCourse);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
