using AutoMapper;
using CoreLayer.DTOs.ContactUs;
using DataLayer.Entities.ContactUs;
using CoreLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace UI.Areas.Admin.Controllers
{
	public class ContactUsController : BaseController
	{
		#region (Dependency injection)
		private readonly IContactUsService _ContactUsService;
		private readonly IMapper _Mapper;
		public ContactUsController(IContactUsService ContactUsService, IMapper Mapper)
		{
			_ContactUsService = ContactUsService;
			_Mapper = Mapper;
		}
		#endregion

		#region (Index)
		[HttpGet("Admin/ContactUs")]
		public async Task<IActionResult> Index()
		{
			ContactUsDTO ContactUsDTO = await _ContactUsService.GetContactUs();

			return View(ContactUsDTO);
		}
		#endregion

		#region (Update)
		#region (Get)
		[HttpGet("Admin/ContactUs/Update/{Id}")]
		public async Task<IActionResult> UpdateContactUs(int Id)
		{
			ContactUs ContactUs = await _ContactUsService.GetContactUsById(Id);

			if (ContactUs == null)
			{
				return NotFound();
			}

			UpdateContactUsDTO UpdateContactUsDTO = _Mapper.Map<UpdateContactUsDTO>(ContactUs);

			return View(UpdateContactUsDTO);
		}
		#endregion

		#region (Post)
		[HttpPost("Admin/ContactUs/Update/{Id}")]
		public async Task<IActionResult> UpdateContactUs(UpdateContactUsDTO UpdateContactUsDTO)
		{
			if (!ModelState.IsValid)
			{
				#region (Client Side Error)
				return View(UpdateContactUsDTO);
				#endregion
			}

			UpdateContactUsResult Result = await _ContactUsService.UpdateContactUs(UpdateContactUsDTO);

			switch (Result)
			{
				case UpdateContactUsResult.Success:
					SuccessAlert();

					return RedirectToAction("Index");
				case UpdateContactUsResult.Error:
					ErrorAlert();
					break;
			}

			return View(UpdateContactUsDTO);
		}
		#endregion
		#endregion
	}
}
