using BackendPRJCT.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendPRJCT.DAL
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions options) : base(options)
		{

		}

		public DbSet<Slider> Sliders { get; set; }
		public DbSet<Teacher> Teachers { get; set; }
		public DbSet<TeacherSkills> TeachersSkills { get; set; }
		public DbSet<TeacherSM> TeacherSMs { get; set; }
	}
}
