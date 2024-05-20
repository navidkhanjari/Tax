using System.ComponentModel.DataAnnotations;

namespace CoreLayer.DTOs.User
{
	public class LoginUserDTO
	{
		[Required]
		public string UserName { get; set; }

		[Required]
		public string Password { get; set; }
	}
}
