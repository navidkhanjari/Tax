namespace CoreLayer.DTOs.Posts
{
	public class UpdatePostDTO
	{
        public int Id { get; set; }
        public string Title { get; set; }
		public string ShortDescription { get; set; }
		public string Description { get; set; }
		public string Authour { get; set; }
		public string ImageName { get; set; }
		public bool Visible { get; set; }
		public string Slug { get; set; }
		public string MetaTitle { get; set; }
		public string MetaDescription { get; set; }
		public string Canonical { get; set; }
	}
	public enum UpdatepostResult
	{
		Success, Error,
	}
}
