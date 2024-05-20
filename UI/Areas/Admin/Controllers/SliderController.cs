using AutoMapper;
using CoreLayer.DTOs.Sliders;
using CoreLayer.Services.Interfaces;
using DataLayer.Entities.Sliders;
using Microsoft.AspNetCore.Mvc;

namespace UI.Areas.Admin.Controllers
{
	public class SliderController : BaseController
	{
		#region (Dependency injection)
		private readonly ISliderService _SliderService;
		private readonly IMapper _Mapper;
		public SliderController(ISliderService SliderService, IMapper Mapper)
		{
			_SliderService = SliderService;
			_Mapper = Mapper;
		}
		#endregion

		#region (Index)
		[HttpGet("Admin/Sliders")]
		public async Task<IActionResult> Index()
		{
			List<SliderDTO> SliderDTOs = await _SliderService.GetSliders();

			return View(SliderDTOs);
		}
		#endregion

		#region (Create)
		#region (Get)
		[HttpGet("Admin/Sliders/Create")]
		public IActionResult CreateSlider()
		{
			return View();
		}
		#endregion

		#region (Post)
		[HttpPost("Admin/Sliders/Create")]
		public async Task<IActionResult> CreateSlider(CreateSliderDTO CreateSliderDTO)
		{
			if (!ModelState.IsValid)
			{
				#region (Client Side Error)
				return View(CreateSliderDTO);
				#endregion
			}

			CreateSliderResult Result = await _SliderService.CreateSlider(CreateSliderDTO);

			switch (Result)
			{
				case CreateSliderResult.Success:
					SuccessAlert();
					return RedirectToAction("Index");
				case CreateSliderResult.Error:
					ErrorAlert();
					break;
			}

			return View(CreateSliderDTO);
		}
		#endregion
		#endregion

		#region (Update)
		#region (Get)
		[HttpGet("Admin/Slider/Update/{Id}")]
		public async Task<IActionResult> UpdateSlider(int Id)
		{
			Slider Slider = await _SliderService.GetSliderById(Id);

			if (Slider == null)
			{
				return NotFound();
			}

			UpdateSliderDTO UpdateSliderDTO = _Mapper.Map<UpdateSliderDTO>(Slider);

			return View(UpdateSliderDTO);
		}
		#endregion

		#region (Post)
		[HttpPost("Admin/Slider/Update/{Id}")]
		public async Task<IActionResult> UpdateSlider(UpdateSliderDTO UpdateSliderDTO)
		{
			if (!ModelState.IsValid)
			{
				#region (Client Side Error)
				return View(UpdateSliderDTO);
				#endregion
			}

			UpdateSliderResult Result = await _SliderService.UpdateSlider(UpdateSliderDTO);

			switch (Result)
			{
				case UpdateSliderResult.Success:
					SuccessAlert();

					return RedirectToAction("Index");
				case UpdateSliderResult.Error:
					ErrorAlert();
					break;
			}

			return View(UpdateSliderDTO);
		}
		#endregion
		#endregion

		#region (Delete)
		#region (Post)
		[HttpPost("Admin/Sliders/Delete/{Id}")]
		public async Task<IActionResult> DeleteSlider(int Id)
		{
			Slider Slider = await _SliderService.GetSliderById(Id);

			if (Slider == null)
			{
				return NotFound();
			}

			bool Result = await _SliderService.Delete(Slider);

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
		[HttpGet("Admin/Sliders/Detail/{Id}")]
		public async Task<IActionResult> DetailSlider(int Id)
		{
			Slider Slider = await _SliderService.GetSliderById(Id);

			if (Slider == null)
			{
				return NotFound();
			}

			SliderDTO SliderDTO = _Mapper.Map<SliderDTO>(Slider);

			return View(SliderDTO);
		}
		#endregion
		#endregion
	}
}
