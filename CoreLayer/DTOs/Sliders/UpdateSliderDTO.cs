using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CoreLayer.DTOs.Sliders
{
	public class UpdateSliderDTO
	{
        public int Id { get; set; }

		[Display(Name = "تصویر فعلی")]
		public string CurrentImageName { get; set; }
		
		[Display(Name = "تصویر جدید")]
		public IFormFile File { get; set; }

		[Display(Name = "عنوان")]
		[Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
		[MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد!")]
		public string Title { get; set; }

		[Display(Name = "توضیحات")]
		[Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
		public string Description { get; set; }

		[Display(Name = "آدرس")]
		[Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
		public string Domain { get; set; }

		[Display(Name = "نمایش در سایت")]
		public bool Visible { get; set; }
	}

	public enum UpdateSliderResult
	{
		Success, Error
	}
}
