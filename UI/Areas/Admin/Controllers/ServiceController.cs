using AutoMapper;
using CoreLayer.DTOs.Services;
using DataLayer.Entities.Services;
using CoreLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace UI.Areas.Admin.Controllers
{
	public class ServiceController : BaseController
	{
		#region (Dependency injection)
		private readonly IServiceService _ServiceService;
		private readonly IMapper _Mapper;
		public ServiceController(IServiceService ServiceService, IMapper Mapper)
		{
			_ServiceService = ServiceService;
			_Mapper = Mapper;
		}
		#endregion

		#region (Index)
		[HttpGet("Admin/Services")]
		public async Task<IActionResult> Index()
		{
			List<ServiceDTO> ServiceDTOs = await _ServiceService.GetServices();

			return View(ServiceDTOs);
		}
		#endregion

		#region (Create)
		#region (Get)
		[HttpGet("Admin/Services/Create")]
		public IActionResult CreateService()
		{
			return View();
		}
		#endregion

		#region (Service)
		[HttpPost("Admin/Services/Create")]
		public async Task<IActionResult> CreateService(CreateServiceDTO CreateServiceDTO)
		{
			if (!ModelState.IsValid)
			{
				#region (Client Side Error)
				return View(CreateServiceDTO);
				#endregion
			}

			CreateServiceResult Result = await _ServiceService.CreateService(CreateServiceDTO);

			switch (Result)
			{
				case CreateServiceResult.Success:
					SuccessAlert();
					return RedirectToAction("Index");
				case CreateServiceResult.Error:
					ErrorAlert();
					break;
			}

			return View(CreateServiceDTO);
		}
		#endregion
		#endregion

		#region (Update)
		#region (Get)
		[HttpGet("Admin/Services/Update/{Id}")]
		public async Task<IActionResult> UpdateService(int Id)
		{
			Service Service = await _ServiceService.GetServiceById(Id);

			if (Service == null)
			{
				return NotFound();
			}

			UpdateServiceDTO UpdateServiceDTO = _Mapper.Map<UpdateServiceDTO>(Service);

			UpdateServiceDTO.CurrentIconName = Service.IconName;

			return View(UpdateServiceDTO);
		}
		#endregion

		#region (Service)
		[HttpPost("Admin/Services/Update/{Id}")]
		public async Task<IActionResult> UpdateService(UpdateServiceDTO UpdateServiceDTO)
		{
			if (!ModelState.IsValid)
			{
				#region (Client Side Error)
				return View(UpdateServiceDTO);
				#endregion
			}

			UpdateServiceResult Result = await _ServiceService.UpdateService(UpdateServiceDTO);

			switch (Result)
			{
				case UpdateServiceResult.Success:
					SuccessAlert();
					return RedirectToAction("Index");
				case UpdateServiceResult.Error:
					ErrorAlert();
					break;
			}

			return View(UpdateServiceDTO);
		}
		#endregion
		#endregion

		#region (Delete)
		#region (Service)
		[HttpPost("Admin/Services/Delete/{Id}")]
		public async Task<IActionResult> DeleteService(int Id)
		{
			Service Service = await _ServiceService.GetServiceById(Id);

			if (Service == null)
			{
				return NotFound();
			}

			bool Result = await _ServiceService.Delete(Service);

			if (Result)
			{
				SuccessAlert();
			}
			else
			{
				ErrorAlert();
			}

			return RedirectToAction("Index");
		}
		#endregion
		#endregion

		#region (Detail)
		#region (Get)
		[HttpGet("Admin/Services/Detail/{Id}")]
		public async Task<IActionResult> DetailService(int Id)
		{
			Service Service = await _ServiceService.GetServiceById(Id);

			if (Service == null)
			{
				return NotFound();
			}

			ServiceDTO ServiceDTO = _Mapper.Map<ServiceDTO>(Service);

			return View(ServiceDTO);
		}
		#endregion
		#endregion
	}
}
