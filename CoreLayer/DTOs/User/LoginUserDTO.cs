using System.ComponentModel.DataAnnotations;

namespace CoreLayer.DTOs.User
{
	public class LoginUserDTO
	{
		[Display(Name = "نام کاربری")]
		[Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
		public string UserName { get; set; }

		[Display(Name = "کلمه عبور")]
		[Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
		public string Password { get; set; }
	}
}
