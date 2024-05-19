using Microsoft.AspNetCore.Http;

namespace CoreLayer.DTOs.Sliders
{
	public class CreateSliderDTO
	{
		public IFormFile Image { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string Domain { get; set; }
		public bool Visible { get; set; }
	}
	public enum CreateSliderResult
	{
		Success, Error
	}
}
