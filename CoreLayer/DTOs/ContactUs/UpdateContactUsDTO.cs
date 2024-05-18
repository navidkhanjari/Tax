namespace CoreLayer.DTOs.ContactUs
{
	public class UpdateContactUsDTO
	{
		public int Id { get; set; }
		public string Description { get; set; }
		public string Email { get; set; }
		public string Number { get; set; }

		public string MetaTitle { get; set; }
		public string MetaDescription { get; set; }
		public string Canonical { get; set; }
	}
	public enum UpdateContactUsResult
	{
		Success, Error
	}
}
