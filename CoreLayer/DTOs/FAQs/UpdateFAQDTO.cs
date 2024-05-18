namespace CoreLayer.DTOs.FAQs
{
	public class UpdateFAQDTO
	{
		public string Question { get; set; }
		public string Answer { get; set; }
		public bool Visible { get; set; }
	}
	public enum UpdateFAQResult
	{
		Success, Error
	}
}
