using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CoreLayer.DTOs.AboutUs
{
	public class UpdateAboutUsDTO
	{
		public int Id { get; set; }

		[Display(Name = "توضیحات")]
		public string Description { get; set; }

		[Display(Name = "تصویر فعلی")]
		public string ImageName { get; set; }

		[Display(Name = "تصویر جدید")]
		public IFormFile? Image { get; set; }

		[Display(Name = "مجموع مشتریان")]
		public string TotalCustomer { get; set; }

		[Display(Name = "مجموع پروژه های انجام شده")]
		public string TotalDoneProject { get; set; }

		[Display(Name = "متا تایتل")]
		[MaxLength(70, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد!")]
		public string MetaTitle { get; set; }

		[Display(Name = "متا دسکریپشن")]
		[MaxLength(255, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد!")]
		public string MetaDescription { get; set; }
	}

	public enum UpdateAboutUsResult
	{
		Success, Error
	}
}
