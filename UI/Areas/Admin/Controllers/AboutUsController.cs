using AutoMapper;
using CoreLayer.DTOs.AboutUs;
using DataLayer.Entities.AboutUs;
using CoreLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace UI.Areas.Admin.Controllers
{
	public class AboutUsController : BaseController
	{
		#region (Dependency injection)
		private readonly IAboutUsService _AboutUsService;
		private readonly IMapper _Mapper;
		public AboutUsController(IAboutUsService AboutUsService, IMapper Mapper)
		{
			_AboutUsService = AboutUsService;
			_Mapper = Mapper;
		}
		#endregion

		#region (Index)
		[HttpGet("Admin/AboutUs")]
		public async Task<IActionResult> Index()
		{
			AboutUsDTO AboutUsDTO = await _AboutUsService.GetAboutUs();

			return View(AboutUsDTO);
		}
		#endregion

		#region (Update)
		#region (Get)
		[HttpGet("Admin/AboutUs/Update/{Id}")]
		public async Task<IActionResult> UpdateAboutUs(int Id)
		{
			AboutUs AboutUs = await _AboutUsService.GetAboutUsById(Id);

			if (AboutUs == null)
			{
				return NotFound();
			}

			UpdateAboutUsDTO UpdateAboutUsDTO = _Mapper.Map<UpdateAboutUsDTO>(AboutUs);

			return View(UpdateAboutUsDTO);
		}
		#endregion

		#region (Post)
		[HttpPost("Admin/AboutUs/Update/{Id}")]
		public async Task<IActionResult> UpdateAboutUs(UpdateAboutUsDTO UpdateAboutUsDTO)
		{
			if (!ModelState.IsValid)
			{
				#region (Client Side Error)
				return View(UpdateAboutUsDTO);
				#endregion
			}

			UpdateAboutUsResult Result = await _AboutUsService.UpdateAboutUs(UpdateAboutUsDTO);

			switch (Result)
			{
				case UpdateAboutUsResult.Success:
					SuccessAlert();

					return RedirectToAction("Index");
				case UpdateAboutUsResult.Error:
					ErrorAlert();
					break;
			}

			return View(UpdateAboutUsDTO);
		}
		#endregion
		#endregion
	}
}
