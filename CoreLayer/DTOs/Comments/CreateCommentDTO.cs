namespace CoreLayer.DTOs.Comments
{
	public class CreateCommentDTO
	{
		public string CustomerFullName { get; set; }
		public string CustomerImage { get; set; }
		public string Jobtitle { get; set; }
		public bool Visible { get; set; }
	}
	public enum CreateCommentResult
	{
		Success, Error
	}
	
}
