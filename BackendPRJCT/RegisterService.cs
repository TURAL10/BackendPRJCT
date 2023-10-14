using BackendPRJCT.DAL;
using BackendPRJCT.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BackendPRJCT
{
    public static class RegisterService
    {
        public static void Register(this IServiceCollection services, IConfiguration config)
        {
            services.AddControllersWithViews();
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            }
            );

            services.AddSession(option =>
            {
                option.IdleTimeout = TimeSpan.FromMinutes(1);
            });

            services.AddIdentity<AppUser, IdentityRole>(IdentityOptions =>
            {
                IdentityOptions.Password.RequireNonAlphanumeric = true;
                IdentityOptions.Password.RequiredLength = 10;
                IdentityOptions.Password.RequireDigit = true;
                IdentityOptions.Password.RequireLowercase = true;
                IdentityOptions.Password.RequireUppercase = true;

                IdentityOptions.User.RequireUniqueEmail = true;

                IdentityOptions.Lockout.MaxFailedAccessAttempts = 5;
                IdentityOptions.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
                IdentityOptions.Lockout.AllowedForNewUsers = true;

            })
                .AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();


        }
    }
}
