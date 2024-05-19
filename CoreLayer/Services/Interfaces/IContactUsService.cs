using CoreLayer.DTOs.ContactUs;
using DataLayer.Entities.ContactUs;

namespace CoreLayer.Services.Interfaces
{
	public interface IContactUsService
	{
		Task<ContactUsDTO> GetContactUs();
		Task<ContactUs> GetContactUsById(int Id);

		Task<bool> Update(ContactUs ContactUs);

		Task<UpdateContactUsResult> UpdateContactUs(UpdateContactUsDTO UpdateContactUsDTO);
	}
}
