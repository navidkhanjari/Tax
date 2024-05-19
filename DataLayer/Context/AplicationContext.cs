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

namespace NakShop.Data.Context
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
	}
}
