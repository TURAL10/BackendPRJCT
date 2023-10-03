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
			vm.TeacherDetails = _appDbContext.TeachersDetails.FirstOrDefault();
			vm.TeachersSkills = _appDbContext.TeachersSkills.ToList();
			vm.TeacherSMs = _appDbContext.TeacherSMs.ToList();
			return View(vm);
		}

		public IActionResult Details(int? id)
		{
			var existTeacher = _appDbContext.Teachers
				.Include(p => p.Image)
				.Include(p => p.Name)
				.Include(p => p.Prof)
				.Include(p=>p.TeacherDetail)
				.Include(p=>p.TeacherSkills)
				.Include(p=>p.TeacherSMs)
				.FirstOrDefault(x => x.Id == id);
			return View(existTeacher);
			


            //return View(_appDbContext.Teachers.FirstOrDefault(x => x.Id == id));

        }
		//private TeacherVM TeacherList()
		//{
		//	TeacherVM vm = new();
		//	vm.TeacherDetails = _appDbContext.TeachersDetails.FirstOrDefault();
  //          vm.TeachersSkills = _appDbContext.TeachersSkills.ToList();
  //          vm.TeacherSMs = _appDbContext.TeacherSMs.ToList();
		//	return vm;
  //      }

    }
}
