namespace CoreLayer.DTOs.Comments
{
	public class CommentsDTO
	{
		public int Id { get; set; }
		public string CustomerFullName { get; set; }
		public string CustomerImageName { get; set; }
		public string Jobtitle { get; set; }
		public string Text { get; set; }
        public bool Visible { get; set; }
	}
}
