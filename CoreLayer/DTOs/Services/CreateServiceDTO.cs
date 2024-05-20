using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CoreLayer.DTOs.Services
{
	public class CreateServiceDTO
	{
		[Display(Name = "آیکن")]
		[Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
		public IFormFile Icon { get; set; }

		[Display(Name = "عنوان")]
		[Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
		[MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد!")]
		public string Title { get; set; }

		[Display(Name = "توضیحات")]
		[Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
		[MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد!")]
		public string Description { get; set; }

		[Display(Name = "نمایش در سایت")]
		public bool Visible { get; set; }
	}
	public enum CreateServiceResult
	{
		Success, Error
	}
}
