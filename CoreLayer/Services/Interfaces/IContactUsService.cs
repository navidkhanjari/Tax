using CoreLayer.DTOs.ContactUs;
using DataLayer.Entities.ContactUs;
using DataLayer.Entities.Services;

namespace CoreLayer.Services.Interfaces
{
	public interface IContactUsService
	{
		Task<ContactUsDTO> GetContactUs();
		Task<ContactUs> GetContactUsById(int Id);

		Task<bool> Update(Service Service);

		Task<UpdateContactUsResult> UpdateContact(UpdateContactUsDTO UpdateContactUsDTO);
	}
}
