using BackendPRJCT.DAL;
using BackendPRJCT.ModelViews;
using Microsoft.AspNetCore.Mvc;

namespace BackendPRJCT.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public AboutController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            AboutVM vm = new();
            vm.About = _appDbContext.Abouts.FirstOrDefault();
            vm.Teachers = _appDbContext.Teachers.ToList();
            vm.TeachersSMs = _appDbContext.TeacherSMs.ToList();
            vm.Testominal = _appDbContext.Testominals.FirstOrDefault();
            vm.NoticeBoards = _appDbContext.NoticesBoards.Take(6).ToList();
            return View(vm);
        }
    }
}
