using System.ComponentModel.DataAnnotations;

namespace CoreLayer.DTOs.ContactUs
{
	public class UpdateContactUsDTO
	{
		public int Id { get; set; }

		[Display(Name = "توضیحات")]
		public string Description { get; set; }

		[Display(Name = "ایمیل")]
		public string Email { get; set; }

		[Display(Name = "شماره های تماس")]
		public string Number { get; set; }

		[Display(Name = "متا تایتل")]
		[MaxLength(70, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد!")]
		public string MetaTitle { get; set; }

		[Display(Name = "متا دسکریپشن")]
		[MaxLength(255, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد!")]
		public string MetaDescription { get; set; }
	}
	public enum UpdateContactUsResult
	{
		Success, Error
	}
}
