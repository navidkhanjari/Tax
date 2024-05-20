using AutoMapper;
using CoreLayer.DTOs.FAQs;
using CoreLayer.Services.Interfaces;
using DataLayer.Entities.FAQ;
using Microsoft.AspNetCore.Mvc;

namespace UI.Areas.Admin.Controllers
{
	public class FAQController : BaseController
	{
		#region (Dependency injection)
		private readonly IFAQService _FAQService;
		private readonly IMapper _Mapper;
		public FAQController(IFAQService FAQService, IMapper Mapper)
		{
			_FAQService = FAQService;
			_Mapper = Mapper;
		}

		#endregion

		#region (Index)
		[HttpGet("Admin/FAQs")]
		public async Task<IActionResult> Index()
		{
			List<FAQs> FAQs = await _FAQService.GetFAQs();

			return View(FAQs);
		}
		#endregion

		#region (Create)
		#region (Get)
		[HttpGet("Admin/FAQs/Create")]
		public IActionResult CreateFAQ()
		{
			return View();
		}
		#endregion

		#region (Post)
		[HttpPost("Admin/FAQs/Create")]
		public async Task<IActionResult> CreateFAQ(CreateFAQDTO CreateFAQDTO)
		{
			if (!ModelState.IsValid)
			{
				#region (Client Side Error)
				return View(CreateFAQDTO);
				#endregion
			}

			CreateFAQResult Result = await _FAQService.CreateFAQ(CreateFAQDTO);

			switch (Result)
			{
				case CreateFAQResult.Success:
					SuccessAlert();
					return RedirectToAction("Index");
				case CreateFAQResult.Error:
					ErrorAlert();
					break;
			}

			return View(CreateFAQDTO);
		}
		#endregion
		#endregion

		#region (Update)
		#region (Get)
		[HttpGet("Admin/FAQ/Update/{Id}")]
		public async Task<IActionResult> UpdateFAQ(int Id)
		{
			FAQs FAQ = await _FAQService.GetFAQById(Id);

			if (FAQ == null)
			{
				return NotFound();
			}

			UpdateFAQDTO UpdateFAQDTO = _Mapper.Map<UpdateFAQDTO>(FAQ);

			return View(UpdateFAQDTO);
		}
		#endregion

		#region (Post)
		[HttpPost("Admin/FAQ/Update/{Id}")]
		public async Task<IActionResult> UpdateFAQ(UpdateFAQDTO UpdateFAQDTO)
		{
			if (!ModelState.IsValid)
			{
				#region (Client Side Error)
				return View(UpdateFAQDTO);
				#endregion
			}

			UpdateFAQResult Result = await _FAQService.UpdateFAQ(UpdateFAQDTO);

			switch (Result)
			{
				case UpdateFAQResult.Success:
					SuccessAlert();

					return RedirectToAction("Index");
				case UpdateFAQResult.Error:
					ErrorAlert();
					break;
			}

			return View(UpdateFAQDTO);
		}
		#endregion
		#endregion
	}
}
