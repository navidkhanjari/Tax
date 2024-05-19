using Microsoft.AspNetCore.Http;

namespace CoreLayer.DTOs.Posts
{
	public class CreatePostDTO
	{
		public string Title { get; set; }
		public string ShortDescription { get; set; }
		public string Description { get; set; }
		public string Authour { get; set; }
		public IFormFile Image { get; set; }
		public bool Visible { get; set; }
		public string Slug { get; set; }
		public string MetaTitle { get; set; }
		public string MetaDescription { get; set; }
		public string MetaKeyWords { get; set; }
	}
	public enum CreatePostResult
	{
		Success, Error, SlugExist
	}
}
