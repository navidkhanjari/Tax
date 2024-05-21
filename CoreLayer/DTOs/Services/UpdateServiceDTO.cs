using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CoreLayer.DTOs.Services
{
	public class UpdateServiceDTO
	{
		public int Id { get; set; }

		[Display(Name = "آیکن فعلی")]
		public string IconName { get; set; }

		[Display(Name = "آیکن جدید")]
		public IFormFile Icon { get; set; }

		[Display(Name = "عنوان")]
		[MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد!")]
		public string Title { get; set; }

		[Display(Name = "توضیحات")]
		[MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد!")]
		public string Description { get; set; }

		[Display(Name = "نمایش در سایت")]
		public bool Visible { get; set; }
	}
	public enum UpdateServiceResult
	{
		Success, Error
	}
}
