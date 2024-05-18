namespace DataLayer.Entities.Users
{
	public class User : Entity
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
	}
}
