using AutoMapper;
using CoreLayer.DTOs.FAQs;
using CoreLayer.Services.Interfaces;
using CoreLayer.Software;
using CoreLayer.Utilities;
using DataLayer.Entities.FAQ;
using Microsoft.EntityFrameworkCore;
using NakShop.Data.Context;
using System.Reflection;

namespace CoreLayer.Services.Implementation
{
	public class FAQsService : IFAQService
	{
		#region (Dependency Injection)
		private readonly ApplicationContext _Context;
		private readonly IMapper _Mapper;
		public FAQsService(ApplicationContext Context, IMapper Mapper)
		{
			this._Context = Context;
			this._Mapper = Mapper;
		}
		#endregion

		#region (Get FAQs)
		public async Task<List<FAQs>> GetFAQs()
		{
			try
			{
				List<FAQs> FAQs = await _Context.FAQs.ToListAsync();

				return FAQs;
			}
			catch (Exception Exception)
			{
				Log.AddError(MethodBase.GetCurrentMethod(), LogType.Error, Exception.Message);

				return null;
			}
		}
		#endregion

		#region (Get FAQ by Id)
		public async Task<FAQs> GetFAQbyId(int Id)
		{
			try
			{
				FAQs FAQs = await _Context.FAQs.SingleOrDefaultAsync(F => F.Id == Id);

				return FAQs;
			}
			catch (Exception Exception)
			{
				Log.AddError(MethodBase.GetCurrentMethod(), LogType.Error, Exception.Message);

				return null;
			}
		}
		#endregion

		#region (Add)
		public async Task<bool> Add(FAQs FAQs)
		{
			try
			{
				_Context.FAQs.Add(FAQs);
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
		public async Task<bool> Update(FAQs FAQs)
		{
			try
			{
				_Context.FAQs.Update(FAQs);
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

		#region (Create FAQ)
		public async Task<CreateFAQResult> CreateFAQ(CreateFAQDTO CreateFAQDTO)
		{
			try
			{
				FAQs FAQs = _Mapper.Map<FAQs>(CreateFAQDTO);

				await Add(FAQs);

				return CreateFAQResult.Success;
			}
			catch (Exception Exception)
			{
				Log.AddError(MethodBase.GetCurrentMethod(), LogType.Error, Exception.Message);

				return CreateFAQResult.Error;
			}
		}
		#endregion

		#region (Update FAQ)
		public async Task<UpdateFAQResult> UpdateFAQ(UpdateFAQDTO UpdateFAQDTO)
		{
			try
			{
				FAQs FAQs = await GetFAQbyId(UpdateFAQDTO.Id);

				_Mapper.Map(UpdateFAQDTO, FAQs);

				await Update(FAQs);

				return UpdateFAQResult.Success;
			}
			catch (Exception Exception)
			{
				Log.AddError(MethodBase.GetCurrentMethod(), LogType.Error, Exception.Message);

				return UpdateFAQResult.Error;
			}
		}
		#endregion
	}
}
