using AutoMapper;
using CoreLayer.DTOs.Sliders;
using CoreLayer.Services.Interfaces;
using CoreLayer.Software;
using CoreLayer.Utilities;
using DataLayer.Context;
using DataLayer.Entities.Sliders;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CoreLayer.Services.Implementation
{
	public class SliderService : ISliderService
	{
		#region (Dependency Injection)
		private readonly ApplicationContext _Context;
		private readonly IMapper _Mapper;
		public SliderService(ApplicationContext Context, IMapper Mapper)
		{
			this._Context = Context;
			this._Mapper = Mapper;
		}
		#endregion

		#region (Get Sliders)
		public async Task<List<SliderDTO>> GetSliders()
		{
			try
			{
				List<Slider> Sliders = await _Context.Sliders.ToListAsync();

				List<SliderDTO> SliderDTOs = _Mapper.Map<List<Slider>, List<SliderDTO>>(Sliders);

				return SliderDTOs;
			}
			catch (Exception Exception)
			{
				Log.AddError(MethodBase.GetCurrentMethod(), LogType.Error, Exception.Message);

				return null;
			}
		}
		#endregion

		#region (Get Sliders For Show)
		public async Task<List<SliderDTO>> GetSlidersForShow()
		{
			try
			{
				List<Slider> Sliders = await _Context.Sliders.Where(S => S.Visible).ToListAsync();

				List<SliderDTO> SliderDTOs = _Mapper.Map<List<Slider>, List<SliderDTO>>(Sliders);

				return SliderDTOs;
			}
			catch (Exception Exception)
			{
				Log.AddError(MethodBase.GetCurrentMethod(), LogType.Error, Exception.Message);

				return null;
			}
		}
		#endregion

		#region (Get Slider By Id)
		public async Task<Slider> GetSliderById(int Id)
		{
			try
			{
				Slider Slider = await _Context.Sliders.SingleOrDefaultAsync(S => S.Id == Id);

				return Slider;
			}
			catch (Exception Exception)
			{
				Log.AddError(MethodBase.GetCurrentMethod(), LogType.Error, Exception.Message);

				return null;
			}
		}
		#endregion


		#region (Add)
		public async Task<bool> Add(Slider Slider)
		{
			try
			{
				await _Context.Sliders.AddAsync(Slider);
				await _Context.SaveChangesAsync();

				return true;
			}
			catch (Exception Exception)
			{
				Log.AddError(MethodBase.GetCurrentMethod(), LogType.Error, Exception.Message);

				return false;
			}
		}
		#endregion

		#region (Update)
		public async Task<bool> Update(Slider Slider)
		{
			try
			{
				_Context.Sliders.Update(Slider);
				await _Context.SaveChangesAsync();

				return true;
			}
			catch (Exception Exception)
			{
				Log.AddError(MethodBase.GetCurrentMethod(), LogType.Error, Exception.Message);

				return false;
			}
		}
		#endregion

		#region (Delete)
		public async Task<bool> Delete(Slider Slider)
		{
			try
			{
				_Context.Sliders.Remove(Slider);
				await _Context.SaveChangesAsync();

				return true;
			}
			catch (Exception Exception)
			{
				Log.AddError(MethodBase.GetCurrentMethod(), LogType.Error, Exception.Message);

				return false;
			}
		}
		#endregion


		#region (Create Slider)
		public async Task<CreateSliderResult> CreateSlider(CreateSliderDTO CreateSliderDTO)
		{
			try
			{
				Slider Slider = _Mapper.Map<Slider>(CreateSliderDTO);

				string ImageName = CreateSliderDTO.Image.SaveFileAndReturnName(FilePath.SliderImageUploadPath);

				Slider.ImageName = ImageName;

				await Add(Slider);

				return CreateSliderResult.Success;
			}
			catch (Exception Exception)
			{
				Log.AddError(MethodBase.GetCurrentMethod(), LogType.Error, Exception.Message);

				return CreateSliderResult.Error;
			}
		}
		#endregion

		#region (Update Slider)
		public async Task<UpdateSliderResult> UpdateSlider(UpdateSliderDTO UpdateSliderDTO)
		{
			try
			{
				Slider Slider = await GetSliderById(UpdateSliderDTO.Id);


				_Mapper.Map(UpdateSliderDTO, Slider);

				if (UpdateSliderDTO.File != null)
				{
					// delete old image
					var ImagePath = Path.Combine(Directory.GetCurrentDirectory(), FilePath.SliderImagePath, Slider.ImageName);

					if (File.Exists(ImagePath))
					{
						File.Delete(ImagePath);
					}

					string ImageName = UpdateSliderDTO.File.SaveFileAndReturnName(FilePath.SliderImageUploadPath);

					Slider.ImageName = ImageName;
				}


				await Update(Slider);

				return UpdateSliderResult.Success;
			}
			catch (Exception Exception)
			{
				Log.AddError(MethodBase.GetCurrentMethod(), LogType.Error, Exception.Message);

				return UpdateSliderResult.Error;
			}
		}
		#endregion
	}
}
