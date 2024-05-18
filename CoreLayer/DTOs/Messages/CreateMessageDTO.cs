namespace CoreLayer.DTOs.Messages
{
	public class CreateMessageDTO
	{
		public string FullName { get; set; }
		public string Email { get; set; }
		public string Number { get; set; }
		public string Description { get; set; }
	}
	public enum CreateMessageResult
	{
		Success, Error
	}
}
