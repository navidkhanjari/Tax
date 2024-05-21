using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CoreLayer.DTOs.Comments
{
	public class UpdateCommentDTO
	{
		public int Id { get; set; }

		[Display(Name = "نام مشتری")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string CustomerFullName { get; set; }

		[Display(Name = "تصویر فعلی مشتری")]
		public string CurrentCustomerImageName { get; set; }

		[Display(Name = "تصویر جدید مشتری")]
        public IFormFile File { get; set; }

		[Display(Name = "عنوان شغلی مشتری")]
        public string Jobtitle { get; set; }

        [Display(Name = "نظر")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string Text { get; set; }

        [Display(Name = "نمایش در سایت")]
		public bool Visible { get; set; }
	}
	public enum UpdateCommentResult
	{
		Success, Error
	}
}
