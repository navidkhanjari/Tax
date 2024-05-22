using CoreLayer.DTOs.Sliders;
using CoreLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace UI.ViewComponents
{
	public class MainSliderViewComponent : ViewComponent
	{
		private readonly ISliderService _SliderService;

		public MainSliderViewComponent(ISliderService SliderService)
		{
			this._SliderService = SliderService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			List<SliderDTO> SliderDTO = await _SliderService.GetSlidersForShow();

			return View("MainSlider", SliderDTO);
		}
	}
}
