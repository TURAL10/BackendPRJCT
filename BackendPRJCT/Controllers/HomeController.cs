using BackendPRJCT.DAL;
using BackendPRJCT.ModelViews;
using Microsoft.AspNetCore.Mvc;

namespace BackendPRJCT.Controllers
{
	public class HomeController : Controller
	{
		private readonly AppDbContext _appDbContext;

		public HomeController(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}
		public IActionResult Index()
		{
			
			HomeVM vm = new();
			vm.Sliders = _appDbContext.Sliders.ToList();
			vm.RightBoards = _appDbContext.RightBoards.ToList();
			vm.Testominal = _appDbContext.Testominals.FirstOrDefault();
			vm.NoticeBoards = _appDbContext.NoticesBoards.ToList();
			vm.Choose = _appDbContext.Chooses.FirstOrDefault();
			vm.Courses = _appDbContext.Courses.Take(3).ToList();
			vm.Events = _appDbContext.Events.Take(8).ToList();
			vm.Blogs = _appDbContext.Blogs.Take(3).ToList();
			return View(vm);
		}
	}
}
