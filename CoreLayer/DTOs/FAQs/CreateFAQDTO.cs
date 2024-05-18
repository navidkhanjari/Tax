namespace CoreLayer.DTOs.FAQs
{
	public class CreateFAQDTO
	{
		public string Question { get; set; }
		public string Answer { get; set; }
		public bool Visible { get; set; }
	}
	public enum CreateFAQResult
	{
		Success, Error
	}
}
