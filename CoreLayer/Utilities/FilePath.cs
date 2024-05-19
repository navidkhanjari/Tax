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
	}
}
