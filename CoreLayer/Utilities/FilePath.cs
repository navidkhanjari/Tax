namespace CoreLayer.Utilities
{
	public class FilePath
	{
		#region (About Us)
		public static readonly string AboutUsImagePath = "/images/aboutus/origin/";
		public static readonly string AboutUsImageUploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/aboutus/origin/");
		#endregion

		#region (Comment)
		public static readonly string CommentImagePath = "/images/comment/origin/";
		public static readonly string CommentImageUploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/comment/origin/");
		#endregion

		#region (Post)
		public static readonly string PostImagePath = "/images/post/origin/";
		public static readonly string PostImageUploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/post/origin/");

		public static readonly string PostContentImagePath = "/images/post/content/origin/";
		public static readonly string PostContentImageUploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/post/content/origin/");
		#endregion

		#region (Service)
		public static readonly string ServiceImagePath = "/images/service/origin/";
		public static readonly string ServiceImageUploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/service/origin/");
		#endregion

		#region (Slider)
		public static readonly string SliderImagePath = "/images/slider/origin/";
		public static readonly string SliderImageUploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/slider/origin/");
		#endregion
	}
}
