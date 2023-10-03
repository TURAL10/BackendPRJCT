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
			return View(vm);
		}
	}
}
