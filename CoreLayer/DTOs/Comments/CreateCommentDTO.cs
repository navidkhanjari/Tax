using Microsoft.AspNetCore.Http;

namespace CoreLayer.DTOs.Comments
{
	public class CreateCommentDTO
	{
		public string CustomerFullName { get; set; }
		public IFormFile CustomerImage { get; set; }
		public string Jobtitle { get; set; }
		public bool Visible { get; set; }
	}
	public enum CreateCommentResult
	{
		Success, Error
	}
	
}
