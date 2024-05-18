namespace CoreLayer.DTOs.Comments
{
	public class UpdateCommentDTO
	{
		public int Id { get; set; }
		public string CustomerFullName { get; set; }
		public string CustomerImage { get; set; }
		public string Jobtitle { get; set; }
		public bool Visible { get; set; }
	}
	public enum UpdateCommentResult
	{
		Success, Error
	}
}
