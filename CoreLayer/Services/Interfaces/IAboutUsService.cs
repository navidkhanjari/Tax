using CoreLayer.DTOs.AboutUs;
using DataLayer.Entities.AboutUs;

namespace CoreLayer.Services.Interfaces
{
	public interface IAboutUsService
	{
		Task<AboutUsDTO> GetAboutUs();
		Task<AboutUs> GetAboutUsById(int Id);

		Task<bool> Update(AboutUs AboutUs);

		Task<UpdateAboutUsResult> UpdateAboutUs(UpdateAboutUsDTO UpdateAboutUsDTO);
	}
}
