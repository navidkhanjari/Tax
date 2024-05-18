using CoreLayer.DTOs.Sliders;
using DataLayer.Entities.Sliders;

namespace CoreLayer.Services.Interfaces
{
	public interface ISliderService
	{
		Task<List<SliderDTO>> GetSliders();
		Task<Slider> GetSliderById(int Id);

		Task<bool> Add(Slider Slider);
		Task<bool> Update(Slider Slider);
		Task<bool> Delete(Slider Slider);

		Task<CreateSliderDTO> CreateSlider(CreateSliderDTO CreateSliderDTO);
		Task<UpdateSliderDTO> UpdateSlider(UpdateSliderDTO UpdateSliderDTO);
	}
}
