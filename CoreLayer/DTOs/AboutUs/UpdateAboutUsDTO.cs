using Microsoft.AspNetCore.Http;

namespace CoreLayer.DTOs.AboutUs
{
	public class UpdateAboutUsDTO
	{
		public int Id { get; set; }
		public string Description { get; set; }
		public string ImageName { get; set; }
		public IFormFile? Image { get; set; }
		public string TotalCustomer { get; set; }
		public string TotalDoneProject { get; set; }

		public string MetaTitle { get; set; }
		public string MetaDescription { get; set; }
		public string Canonical { get; set; }
	}

	public enum UpdateAboutUsResult
	{
		Success, Error
	}
}
