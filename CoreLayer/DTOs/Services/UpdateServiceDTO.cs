namespace CoreLayer.DTOs.Services
{
	public class UpdateServiceDTO
	{
		public int Id { get; set; }
		public string IconName { get; set; }
		public string Title { get; set; }
		public String Description { get; set; }
		public bool Visible { get; set; }
	}
	public enum UpdateServiceResult
	{
		Success, Error
	}
}
