using CoreLayer.DTOs.AboutUs;
using CoreLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace UI.ViewComponents
{
	public class AboutUsViewComponent : ViewComponent
	{
		private readonly IAboutUsService _AboutUsService;
		public AboutUsViewComponent(IAboutUsService AboutUsService)
		{
			this._AboutUsService = AboutUsService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			AboutUsDTO AboutUsDTO = await _AboutUsService.GetAboutUs();

			return View("AboutUs", AboutUsDTO);
		}
	}
}

