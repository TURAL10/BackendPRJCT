using BackendPRJCT.DAL;
using Microsoft.AspNetCore.Mvc;

namespace BackendPRJCT.ViewComponents
{
    public class SubscribeViewComponent:ViewComponent
    {
        private readonly AppDbContext _appDbContext;

        public SubscribeViewComponent(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
