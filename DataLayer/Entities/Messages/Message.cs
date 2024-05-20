using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities.Messages
{
	public class Message : Entity
	{
		[Required]
		[MaxLength(100)]
		public string FullName { get; set; }

		[MaxLength(300)]
		public string Email { get; set; }

		[Required]
		[MaxLength(11)]
		public string Number { get; set; }

		[Required]
		[MaxLength(600)]
		public string Description { get; set; }
		public DateTime CreateDate { get; set; }
	}
}
