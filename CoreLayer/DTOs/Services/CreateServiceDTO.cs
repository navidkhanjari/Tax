using Microsoft.AspNetCore.Http;

namespace CoreLayer.DTOs.Services
{
	public class CreateServiceDTO
	{
		public IFormFile Icon { get; set; }
		public string Title { get; set; }
		public String Description { get; set; }
		public bool Visible { get; set; }
	}
	public enum CreateServiceResult
	{
		Success, Error
	}
}
