using System.ComponentModel.DataAnnotations;

namespace CoreLayer.DTOs.FAQs
{
	public class CreateFAQDTO
	{
		[Display(Name = "سوال")]
		[Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
		public string Question { get; set; }

		[Display(Name = "پاسخ")]
		[Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
		public string Answer { get; set; }
		
		[Display(Name = "نمایش در سایت")]
		public bool Visible { get; set; }
	}
	public enum CreateFAQResult
	{
		Success, Error
	}
}
