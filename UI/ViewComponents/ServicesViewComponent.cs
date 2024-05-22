using CoreLayer.DTOs.Services;
using CoreLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace UI.ViewComponents
{
	public class ServicesViewComponent : ViewComponent
	{
		private readonly IServiceService _ServiceService;
		public ServicesViewComponent(IServiceService ServiceService)
		{
			this._ServiceService = ServiceService;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			List<ServiceDTO> ServiceDTOs = await _ServiceService.GetServicesForShow();

			return View("Services", ServiceDTOs);
		}
	}
}
