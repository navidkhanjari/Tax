using AutoMapper;
using CoreLayer.DTOs.Services;
using CoreLayer.Services.Interfaces;
using CoreLayer.Software;
using CoreLayer.Utilities;
using DataLayer.Entities.Services;
using Microsoft.EntityFrameworkCore;
using NakShop.Data.Context;
using System.Reflection;

namespace CoreLayer.Services.Implementation
{
	public class ServiceService : IServiceService
	{
		#region (Dependency Injection)
		private readonly ApplicationContext _Context;
		private readonly IMapper _Mapper;
		public ServiceService(ApplicationContext Context, IMapper Mapper)
		{
			this._Context = Context;
			this._Mapper = Mapper;
		}
		#endregion

		#region (Get Services)
		public async Task<List<ServiceDTO>> GetServices()
		{
			try
			{
				List<Service> Services = await _Context.Services.ToListAsync();

				List<ServiceDTO> ServiceDTOs = _Mapper.Map<List<Service>, List<ServiceDTO>>(Services);

				return ServiceDTOs;
			}
			catch (Exception Exception)
			{
				Log.AddError(MethodBase.GetCurrentMethod(), LogType.Error, Exception.Message);

				return null;
			}
		}
		#endregion

		#region (Get Service By Id)
		public async Task<Service> GetServiceById(int Id)
		{
			try
			{
				Service Service = await _Context.Services.SingleOrDefaultAsync(S => S.Id == Id);

				return Service;
			}
			catch (Exception Exception)
			{
				Log.AddError(MethodBase.GetCurrentMethod(), LogType.Error, Exception.Message);

				return null;
			}
		}
		#endregion


		#region (Add)
		public async Task<bool> Add(Service Service)
		{
			try
			{
				_Context.Services.Add(Service);
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
		public async Task<bool> Update(Service Service)
		{
			try
			{
				_Context.Services.Update(Service);
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
		public async Task<bool> Delete(Service Service)
		{
			try
			{
				_Context.Services.Remove(Service);
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


		#region (Create Service)
		public async Task<CreateServiceResult> CreateService(CreateServiceDTO CreateServiceDTO)
		{
			try
			{
				Service Service = _Mapper.Map<Service>(CreateServiceDTO);

				string IconName = CreateServiceDTO.Icon.SaveFileAndReturnName(FilePath.ServiceImageUploadPath);

				Service.IconName = IconName;

				await Add(Service);

				return CreateServiceResult.Success;
			}
			catch (Exception Exception)
			{
				Log.AddError(MethodBase.GetCurrentMethod(), LogType.Error, Exception.Message);

				return CreateServiceResult.Error;
			}
		}
		#endregion

		#region (Update Service)
		public async Task<UpdateServiceResult> UpdateService(UpdateServiceDTO UpdateServiceDTO)
		{
			try
			{
				Service Service = await GetServiceById(UpdateServiceDTO.Id);

				_Mapper.Map(UpdateServiceDTO, Service);

				if (UpdateServiceDTO.Icon != null)
				{
					//delete old icon
					var ImagePath = Path.Combine(Directory.GetCurrentDirectory(), FilePath.ServiceImagePath, Service.IconName);

					if (File.Exists(ImagePath))
					{
						File.Delete(ImagePath);
					}

					string IconName = UpdateServiceDTO.Icon.SaveFileAndReturnName(FilePath.ServiceImageUploadPath);

					Service.IconName = IconName;
				}

				await Update(Service);

				return UpdateServiceResult.Success;
			}
			catch (Exception Exception)
			{
				Log.AddError(MethodBase.GetCurrentMethod(), LogType.Error, Exception.Message);

				return UpdateServiceResult.Error;
			}
		}
		#endregion
	}
}
