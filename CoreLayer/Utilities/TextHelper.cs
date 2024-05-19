namespace CoreLayer.Utilities
{
	public static class TextHelper
	{
		public static string ToSlug(this string value)
		{
			return value.Trim().ToLower()
				.Replace("~", "")
				.Replace("@", "")
				.Replace("#", "")
				.Replace("$", "")
				.Replace("%", "")
				.Replace("^", "")
				.Replace("&", "")
				.Replace("*", "")
				.Replace("(", "")
				.Replace(")", "")
				.Replace("+", "")
				.Replace(" ", "-")
				.Replace(">", "")
				.Replace("<", "")
				.Replace(@"\", "")
				.Replace("/", "");
		}

		public static string SlugToText(this string value)
		{
			return value.Trim().ToLower()
			   .Replace("-", " ")
			   .Replace("+", " ");
		}
	}
}
