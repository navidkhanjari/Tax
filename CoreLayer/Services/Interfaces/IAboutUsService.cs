using CoreLayer.DTOs.AboutUs;
using DataLayer.Entities.AboutUs;
using DataLayer.Entities.Services;

namespace CoreLayer.Services.Interfaces
{
	public interface IAboutUsService
	{
		Task<AboutUsDTO> GetAboutUs();
		Task<AboutUs> GetAboutUsById(int Id);

		Task<bool> Update(Service Service);

		Task<UpdateAboutUsResult> UpdateAboutUs(UpdateAboutUsDTO UpdateAboutUsDTO);
	}
}
