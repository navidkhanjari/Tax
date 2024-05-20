using System.ComponentModel.DataAnnotations;

namespace CoreLayer.DTOs.FAQs
{
	public class UpdateFAQDTO
	{
		public int Id { get; set; }

		[Display(Name = "سوال")]
		public string Question { get; set; }

		[Display(Name = "پاسخ")]
		public string Answer { get; set; }

		[Display(Name = "نمایش در سایت")]
		public bool Visible { get; set; }
	}
	public enum UpdateFAQResult
	{
		Success, Error
	}
}
