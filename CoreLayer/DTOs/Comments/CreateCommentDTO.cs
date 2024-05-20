using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CoreLayer.DTOs.Comments
{
	public class CreateCommentDTO
	{
		[Display(Name = "نام مشتری")]
		[Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
		public string CustomerFullName { get; set; }

		[Display(Name = "تصویر مشتری (اختیاری)")]
		public IFormFile CustomerImage { get; set; }

		[Display(Name = "عنوان شغلی مشتری (اختیاری)")]
		[Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
		public string Jobtitle { get; set; }

		[Display(Name = "نمایش در سایت")]
		[Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
		public bool Visible { get; set; }
	}

	public enum CreateCommentResult
	{
		Success, Error
	}
}
