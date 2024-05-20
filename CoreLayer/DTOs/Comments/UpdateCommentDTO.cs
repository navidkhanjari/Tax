using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CoreLayer.DTOs.Comments
{
	public class UpdateCommentDTO
	{
		public int Id { get; set; }

		[Display(Name = "نام مشتری")]
		public string CustomerFullName { get; set; }

		[Display(Name = "تصویر فعلی مشتری")]
		public string CustomerImageName { get; set; }

		[Display(Name = "تصویر جدید مشتری")]
        public IFormFile CustomerImage { get; set; }

		[Display(Name = "عنوان شغلی مشتری")]
        public string Jobtitle { get; set; }

		[Display(Name = "نمایش در سایت")]
		public bool Visible { get; set; }
	}
	public enum UpdateCommentResult
	{
		Success, Error
	}
}
