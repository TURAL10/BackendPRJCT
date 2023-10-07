﻿using BackendPRJCT.DAL;
using BackendPRJCT.Models;
using BackendPRJCT.ModelViews.AdminBlog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendPRJCT.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class BlogController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public BlogController(AppDbContext context)
        {
            _appDbContext = context;
        }

        public IActionResult Index()
        {
            var existResult = _appDbContext.Blogs
                .ToList();
            return View(existResult);
        }
        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();
            var existResult = _appDbContext.Blogs
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
        public IActionResult Create(CreateBlogVM createBlogVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (_appDbContext.Blogs.Any(t => t.Title == createBlogVM.Title))
            {
                ModelState.AddModelError("Title", "This title doesn't exits");
            }
            Blog blog = new();
            blog.Image = createBlogVM.Image;
            blog.Title = createBlogVM.Title;
            blog.Name = createBlogVM.Name;
            blog.Description = createBlogVM.Description;
            blog.Month = createBlogVM.Month;
            blog.Day = createBlogVM.Day;
            blog.Year = createBlogVM.Year;
            blog.Comment = createBlogVM.Comment;
            _appDbContext.Blogs.Add(blog);
            _appDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Update(int? id)
        {
            if (id == null) return NotFound();
            var existResult = _appDbContext.Blogs.FirstOrDefault(i => i.Id == id);
            if (existResult == null) return NotFound();
            var updadeBlogVM = new UpdateBlogVM
            {
                Id = existResult.Id,
                Image = existResult.Image,
                Title = existResult.Title,
                Name = existResult.Name,
                Description = existResult.Description,
                Month = existResult.Month,
                Day = existResult.Day,
                Year = existResult.Year,
                Comment = existResult.Comment,
            };
            return View(updadeBlogVM);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(UpdateBlogVM updadeBlogVM)
        {
            if (!ModelState.IsValid) return View();
            var existResult = _appDbContext.Blogs.FirstOrDefault(i => i.Id == updadeBlogVM.Id);

            if (_appDbContext.Blogs.Any(c => c.Title == updadeBlogVM.Title && c.Id != existResult.Id))
            {
                ModelState.AddModelError("Title", "artiq movcutdur");
                return View();
            }

            existResult.Image = updadeBlogVM.Image;
            existResult.Title = updadeBlogVM.Title;
            existResult.Name = updadeBlogVM.Name;
            existResult.Description = updadeBlogVM.Description;
            existResult.Month = updadeBlogVM.Month;
            existResult.Day = updadeBlogVM.Day;
            existResult.Year = updadeBlogVM.Year;
            existResult.Comment = updadeBlogVM.Comment;

            _appDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            if (id == 0) return NotFound();
            var deletedBlog = _appDbContext.Blogs.FirstOrDefault(c => c.Id == id);
            if (deletedBlog == null) return NotFound();
            _appDbContext.Blogs.Remove(deletedBlog);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
