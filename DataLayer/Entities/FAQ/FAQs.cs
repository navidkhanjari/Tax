using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities.FAQ
{
	public class FAQs : Entity
	{
		[Required]
		public string Question { get; set; }

        [Required]
        public string Answer { get; set; }
		public bool Visible { get; set; }
	}
}
