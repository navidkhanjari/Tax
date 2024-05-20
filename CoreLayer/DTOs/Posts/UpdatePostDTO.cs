using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CoreLayer.DTOs.Posts
{
	public class UpdatePostDTO
	{
		public int Id { get; set; }

		[Display(Name = "عنوان")]
		[MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد!")]
		public string Title { get; set; }
		
		[Display(Name = "توضیح کوتاه")]
		[Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
		[MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد!")]
		public string ShortDescription { get; set; }
		
		[Display(Name = "توضیحات")]
		public string Description { get; set; }

		[Display(Name = "نویسنده")]
		[MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد!")]
		public string Authour { get; set; }


		[Display(Name = "تصویر فعلی")]
		[Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
		public string ImageName { get; set; }


		[Display(Name = "تصویر جدید")]
		[Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
		public IFormFile Image { get; set; }

		[Display(Name = "نمایش در سایت")]
		public bool Visible { get; set; }

		[Display(Name = "اسلاگ (URL)")]
		[Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
		[MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد!")]
		public string Slug { get; set; }
		
		[Display(Name = "متا تایتل")]
		[MaxLength(70, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد!")]
		public string MetaTitle { get; set; }

		[Display(Name = "متا دسکریپشن")]
		[MaxLength(255, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد!")]
		public string MetaDescription { get; set; }

		[Display(Name = "کلمات کلیدی")]
		[MaxLength(255, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد!")]
		public string MetaKeyWords { get; set; }
	}
	public enum UpdatePostResult
	{
		Success, Error, SlugExist
	}
}
