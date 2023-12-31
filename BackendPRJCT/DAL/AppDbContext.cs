﻿using BackendPRJCT.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BackendPRJCT.DAL
{
	public class AppDbContext : IdentityDbContext<AppUser>
	{
		public AppDbContext(DbContextOptions options) : base(options)
		{

		}

		public DbSet<Slider> Sliders { get; set; }
		public DbSet<Teacher> Teachers { get; set; }
		public DbSet<TeacherSkills> TeachersSkills { get; set; }
		public DbSet<TeacherSM> TeacherSMs { get; set; }
		public DbSet<RightBoard> RightBoards { get; set; }
		public DbSet<Blog> Blogs { get; set; }
		public DbSet<Event> Events { get; set; }
		public DbSet<Speaker> Speakers { get; set; }
		public DbSet<Course> Courses { get; set; }
		public DbSet<Feature> Features { get; set; }
		public DbSet<About> Abouts { get; set; }
		public DbSet<Testominal> Testominals { get; set; }
		public DbSet<NoticeBoard> NoticesBoards { get; set; }
		public DbSet<Choose> Chooses { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<LatestPost> LatestPosts { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);

            modelbuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Member",
                    NormalizedName = "MEMBER",
                    ConcurrencyStamp = Guid.NewGuid().ToString()

                },
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = Guid.NewGuid().ToString(),

                },
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "SuperAdmin",
                    NormalizedName = "SUPERADMIN",
                    ConcurrencyStamp = Guid.NewGuid().ToString(),

                }
                );
        }
    }
}
