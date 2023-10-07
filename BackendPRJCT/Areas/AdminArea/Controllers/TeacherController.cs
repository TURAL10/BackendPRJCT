﻿using BackendPRJCT.DAL;
using BackendPRJCT.Models;
using BackendPRJCT.ModelViews.AdminTeacher;
using Microsoft.AspNetCore.Mvc;

namespace BackendPRJCT.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class TeacherController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public TeacherController(AppDbContext context)
        {
            _appDbContext = context;
        }

        public IActionResult Index()
        {
            var existResult = _appDbContext.Teachers.ToList();
            return View(existResult);
        }
        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();
            var existResult = _appDbContext.Teachers.FirstOrDefault(c => c.Id == id);
            if (existResult == null) return NotFound();
            return View(existResult);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(CreateTeacherVM createTeacherVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (_appDbContext.Teachers.Any(t => t.Name == createTeacherVM.Name))
            {
                ModelState.AddModelError("Name", "This Name doesn't exits");
            }
            Teacher teacher = new();
            teacher.Image = createTeacherVM.Image;
            teacher.Name = createTeacherVM.Name;
            teacher.Prof = createTeacherVM.Prof;

            teacher.AboutMe = createTeacherVM.AboutMe;
            teacher.Degree = createTeacherVM.Degree;
            teacher.Experience = createTeacherVM.Experience;
            teacher.Hobby = createTeacherVM.Hobby;
            teacher.Faculty = createTeacherVM.Faculty;
            teacher.Mail = createTeacherVM.Mail;
            teacher.Number = createTeacherVM.Number;
            teacher.Skype = createTeacherVM.Skype;
            _appDbContext.Teachers.Add(teacher);
            _appDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Update(int? id)
        {
            if (id == null) return NotFound();
            var existResult = _appDbContext.Teachers.FirstOrDefault(i => i.Id == id);
            if (existResult == null) return NotFound();
            var updateteacherVM = new UpdateTeacherVM
            {
                Id = existResult.Id,
                Image = existResult.Image,
                Name = existResult.Name,
                Prof = existResult.Prof,

                AboutMe = existResult.AboutMe,
                Degree = existResult.Degree,
                Experience = existResult.Experience,
                Hobby = existResult.Hobby,
                Faculty = existResult.Faculty,
                Mail = existResult.Mail,
                Number = existResult.Number,
                Skype = existResult.Skype,

            };
            return View(updateteacherVM);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(UpdateTeacherVM updateTeacherVM)
        {
            if (!ModelState.IsValid) return View();
            var existResult = _appDbContext.Teachers.FirstOrDefault(i => i.Id == updateTeacherVM.Id);

            if (_appDbContext.Teachers.Any(c => c.Name == updateTeacherVM.Name && c.Id != existResult.Id))
            {
                ModelState.AddModelError("Title", "artiq movcutdur");
                return View();
            }

            existResult.Image = updateTeacherVM.Image;
            existResult.Name = updateTeacherVM.Name;
            existResult.Prof = updateTeacherVM.Prof;

            existResult.AboutMe = updateTeacherVM.AboutMe;
            existResult.Degree = updateTeacherVM.Degree;
            existResult.Experience = updateTeacherVM.Experience;
            existResult.Hobby = updateTeacherVM.Hobby;
            existResult.Faculty = updateTeacherVM.Faculty;
            existResult.Mail = updateTeacherVM.Mail;
            existResult.Number = updateTeacherVM.Number;
            existResult.Skype = updateTeacherVM.Skype;
            _appDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            if (id == 0) return NotFound();
            var deletedTeacher = _appDbContext.Teachers.FirstOrDefault(c => c.Id == id);
            if (deletedTeacher == null) return NotFound();
            _appDbContext.Teachers.Remove(deletedTeacher);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}