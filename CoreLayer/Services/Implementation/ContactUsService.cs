using AutoMapper;
using CoreLayer.DTOs.ContactUs;
using CoreLayer.Services.Interfaces;
using CoreLayer.Software;
using DataLayer.Entities.ContactUs;
using Microsoft.EntityFrameworkCore;
using NakShop.Data.Context;
using System.Reflection;

namespace CoreLayer.Services.Implementation
{
	public class ContactUsService : IContactUsService
	{
		#region (Dependency Injection)
		private readonly ApplicationContext _Context;
		private readonly IMapper _Mapper;
		public ContactUsService(ApplicationContext Context, IMapper Mapper)
		{
			this._Context = Context;
			this._Mapper = Mapper;
		}

		#endregion

		#region (Get Contact Us)
		public async Task<ContactUsDTO> GetContactUs()
		{
			try
			{
				ContactUs ContactUs = await _Context.ContactUs.LastAsync();

				if (ContactUs != null)
				{
					ContactUsDTO ContactUsDTO = _Mapper.Map<ContactUsDTO>(ContactUs);

					return ContactUsDTO;
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

		#region (Get Contact Us By Id)
		public async Task<ContactUs> GetContactUsById(int Id)
		{
			try
			{
				ContactUs ContactUs = await _Context.ContactUs.SingleOrDefaultAsync(A => A.Id == Id);

				return ContactUs;
			}
			catch (Exception Exception)
			{
				Log.AddError(MethodBase.GetCurrentMethod(), LogType.Error, Exception.Message);

				return null;
			}
		}

		#endregion

		#region (Update)
		public async Task<bool> Update(ContactUs ContactUs)
		{
			try
			{
				_Context.ContactUs.Update(ContactUs);
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

		#region (Update Contact Us)
		public async Task<UpdateContactUsResult> UpdateContactUs(UpdateContactUsDTO UpdateContactUsDTO)
		{
			try
			{
				ContactUs ContactUs = await GetContactUsById(UpdateContactUsDTO.Id);

				_Mapper.Map(UpdateContactUsDTO, ContactUs);

				await Update(ContactUs);

				return UpdateContactUsResult.Success;
			}
			catch (Exception Exception)
			{
				Log.AddError(MethodBase.GetCurrentMethod(), LogType.Error, Exception.Message);

				return UpdateContactUsResult.Error;
			}
		}
		#endregion
	}
}
