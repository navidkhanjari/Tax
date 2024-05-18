using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities.Users
{
	public class User : Entity
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }

		[Required]
		public string UserName { get; set; }

		[Required]
		public string Password { get; set; }
	}
}
