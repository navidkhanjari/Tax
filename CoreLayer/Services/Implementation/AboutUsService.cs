﻿using AutoMapper;
using CoreLayer.DTOs.AboutUs;
using CoreLayer.Services.Interfaces;
using CoreLayer.Software;
using CoreLayer.Utilities;
using DataLayer.Entities.AboutUs;
using Microsoft.EntityFrameworkCore;
using DataLayer.Context;
using System.Reflection;

namespace CoreLayer.Services.Implementation
{
	public class AboutUsService : IAboutUsService
	{
		#region (Dependency Injection)
		private readonly ApplicationContext _Context;
		private readonly IMapper _Mapper;
		public AboutUsService(ApplicationContext Context, IMapper Mapper)
		{
			this._Context = Context;
			this._Mapper = Mapper;
		}
		#endregion

		#region (Get About Us)
		public async Task<AboutUsDTO> GetAboutUs()
		{
			try
			{
				AboutUs AboutUs = await _Context.AboutUs.SingleOrDefaultAsync();

				if (AboutUs != null)
				{
					AboutUsDTO AboutUsDTO = _Mapper.Map<AboutUsDTO>(AboutUs);

					return AboutUsDTO;
				}

				return null;
			}
			catch (Exception Exception)
			{
				Log.AddError(MethodBase.GetCurrentMethod(), LogType.Error, Exception.Message);

				return null;
			}
		}
		#endregion

		#region (Get About Us By Id)
		public async Task<AboutUs> GetAboutUsById(int Id)
		{
			try
			{
				AboutUs AboutUs = await _Context.AboutUs.SingleOrDefaultAsync(A => A.Id == Id);

				return AboutUs;
			}
			catch (Exception Exception)
			{
				Log.AddError(MethodBase.GetCurrentMethod(), LogType.Error, Exception.Message);

				return null;
			}
		}
		#endregion


		#region (Update)
		public async Task<bool> Update(AboutUs AboutUs)
		{
			try
			{
				_Context.AboutUs.Update(AboutUs);
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


		#region (Update About Us)
		public async Task<UpdateAboutUsResult> UpdateAboutUs(UpdateAboutUsDTO UpdateAboutUsDTO)
		{
			try
			{
				AboutUs AboutUs = await GetAboutUsById(UpdateAboutUsDTO.Id);

				_Mapper.Map(UpdateAboutUsDTO, AboutUs);

				if (UpdateAboutUsDTO.File != null)
				{
					//delete old image

					var ImagePath = Path.Combine(Directory.GetCurrentDirectory(), FilePath.AboutUsImagePath, AboutUs.ImageName);

					if (File.Exists(ImagePath))
					{
						File.Delete(ImagePath);
					}

					string ImageName = UpdateAboutUsDTO.File.SaveFileAndReturnName(FilePath.AboutUsImageUploadPath);

					AboutUs.ImageName = ImageName;
				}

				await Update(AboutUs);

				return UpdateAboutUsResult.Success;
			}
			catch (Exception Exception)
			{
				Log.AddError(MethodBase.GetCurrentMethod(), LogType.Error, Exception.Message);

				return UpdateAboutUsResult.Error;
			}
		}
		#endregion
	}
}
