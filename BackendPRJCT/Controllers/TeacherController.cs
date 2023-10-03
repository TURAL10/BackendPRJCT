using BackendPRJCT.DAL;
using BackendPRJCT.Models;
using BackendPRJCT.ModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendPRJCT.Controllers
{
	public class TeacherController : Controller
	{
		private readonly AppDbContext _appDbContext;

		public TeacherController(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}
		public IActionResult Index()
		{
			TeacherVM vm = new();
			vm.Teachers = _appDbContext.Teachers.ToList();
			vm.TeachersSkills = _appDbContext.TeachersSkills.ToList();
			vm.TeacherSMs = _appDbContext.TeacherSMs.ToList();
			return View(vm);
		}

		public IActionResult Details(int? id)
		{
			var existTeacher = _appDbContext.Teachers
				.Include(p=>p.TeacherSMs)
				.Include(p=> p.TeacherSkills)
				.FirstOrDefault(x => x.Id == id);
			return View(existTeacher);
        }
    }
}
