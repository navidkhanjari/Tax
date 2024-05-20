using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities.Posts
{
	public class Post : Entity
	{
		[Required]
		[MaxLength(50)]
		public string Title { get; set; }

		[Required]
		[MaxLength(250)]
		public string ShortDescription { get; set; }

		[Required]
		public string Description { get; set; }

		[Required]
		public string Authour { get; set; }

		[Required]
		public string ImageName { get; set; }

		public int Visit { get; set; } = 0;
		public bool Visible { get; set; }

		public string Slug { get; set; }

		public DateTime PublishDate { get; set; }

		public string MetaTitle { get; set; }
		public string MetaDescription { get; set; }
        public string MetaKeyWords { get; set; }
	}
}
