namespace DataLayer.Entities.AboutUs
{
	public class AboutUs : Entity
	{
		public string Description { get; set; }
		public string ImageName { get; set; }
		public string TotalCustomer { get; set; }
		public string TotalDoneProject { get; set; }

		public string MetaTitle { get; set; }
		public string MetaDescription { get; set; }
	}
}
