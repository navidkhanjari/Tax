using System.ComponentModel.DataAnnotations;

namespace CoreLayer.DTOs.Messages
{
	public class CreateMessageDTO
	{
		[Display(Name = "نام")]
		[Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
		[MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد!")]
		public string FullName { get; set; }

		[Display(Name = "ایمیل")]
		[MaxLength(300, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد!")]
		[EmailAddress(ErrorMessage = "ایمیل وارد شده نا معتبر است")]
		public string Email { get; set; }

		[Display(Name = "شماره تماس")]
		[Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
		[MaxLength(11, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد!")]
		public string Number { get; set; }

		[Display(Name = "متن پیام")]
		[Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
		[MaxLength(600, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد!")]
		public string Description { get; set; }
	}
	public enum CreateMessageResult
	{
		Success, Error
	}
}
