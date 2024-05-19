using AutoMapper;
using CoreLayer.DTOs.AboutUs;
using CoreLayer.Services.Interfaces;
using CoreLayer.Software;
using CoreLayer.Utilities;
using DataLayer.Entities.AboutUs;
using Microsoft.EntityFrameworkCore;
using NakShop.Data.Context;
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
				AboutUs AboutUs = await _Context.AboutUs.LastAsync();

				if (AboutUs != null)
				{
					AboutUsDTO aboutUsDTO = _Mapper.Map<AboutUsDTO>(AboutUs);
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
				AboutUs AboutUs = _Mapper.Map<AboutUs>(UpdateAboutUsDTO);

				if (UpdateAboutUsDTO.Image != null)
				{
					string ImageName = UpdateAboutUsDTO.Image.SaveFileAndReturnName(FilePath.AboutUsImageUploadPath);

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
