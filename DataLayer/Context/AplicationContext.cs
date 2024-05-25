using DataLayer.Entities.AboutUs;
using DataLayer.Entities.Comments;
using DataLayer.Entities.ContactUs;
using DataLayer.Entities.FAQ;
using DataLayer.Entities.Messages;
using DataLayer.Entities.Posts;
using DataLayer.Entities.Services;
using DataLayer.Entities.Sliders;
using DataLayer.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Context
{
	public class ApplicationContext : DbContext
	{
		public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
		{

		}

		public DbSet<AboutUs> AboutUs { get; set; }
		public DbSet<Comment> Comments { get; set; }
		public DbSet<ContactUs> ContactUs { get; set; }
		public DbSet<FAQs> FAQs { get; set; }
		public DbSet<Message> Messages { get; set; }
		public DbSet<Post> Posts { get; set; }
		public DbSet<Service> Services { get; set; }
		public DbSet<Slider> Sliders { get; set; }
		public DbSet<User> Users { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>().HasData(new User()
			{
				Id = 1,
				UserName = "SanazKhani",
				Password = "70-66-04-FE-12-0C-ED-D1-00-A2-F6-55-5E-3B-A8-9F",
				FirstName = "ساناز",
				LastName = "خانی"
			}, new User()
			{
				Id = 2,
				UserName = "ZahraJangjoo",
				Password = "6C-6F-BB-1E-6A-47-DA-3A-4D-A4-77-3C-8E-41-07-8F",
				FirstName = "زهرا",
				LastName = "جنگجو"
			}, new User()
			{
				Id = 3,
				UserName = "navidkhanjari",
				Password = "AC-D6-E1-0F-38-B8-CF-14-BE-F4-88-B6-51-5F-D1-0F",
				FirstName = "نوید",
				LastName = "خنجری"
			});

			modelBuilder.Entity<AboutUs>().HasData(new AboutUs()
			{
				Id = 1,
				Description = "درباره ما",
				ImageName = null,
				MetaDescription = "meta",
				MetaTitle = "meta",
				TotalCustomer = "1",
				TotalDoneProject = "1",
			});

			modelBuilder.Entity<ContactUs>().HasData(new ContactUs()
			{
				Id = 1,
				Description = "تماس با ما",
				Email = "Email.com",
				Number = "09",
				MetaTitle = "meta",
				MetaDescription = "meta",
			});
		}
	}
}
