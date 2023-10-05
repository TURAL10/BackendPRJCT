using BackendPRJCT.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var config = builder.Configuration;


builder.Services.AddDbContext<AppDbContext>(opt =>
{
	opt.UseSqlServer(config.GetConnectionString("DefaultConnection"));
});
var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=DashBoard}/{action=Index}/{id?}"
          );

app.MapControllerRoute("default", "{controller=home}/{action=index}/{id?}");

app.UseStaticFiles();

app.Run();