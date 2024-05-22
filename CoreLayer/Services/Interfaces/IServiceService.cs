using CoreLayer.DTOs.Posts;
using CoreLayer.DTOs.Services;
using DataLayer.Entities.Services;

namespace CoreLayer.Services.Interfaces
{
	public interface IServiceService
	{
		Task<List<ServiceDTO>> GetServices();
		Task<List<ServiceDTO>> GetServicesForShow();
		Task<Service> GetServiceById(int Id);

		Task<bool> Add(Service Service);
		Task<bool> Update(Service Service);
		Task<bool> Delete(Service Service);

		Task<CreateServiceResult> CreateService(CreateServiceDTO CreateServiceDTO);
		Task<UpdateServiceResult> UpdateService(UpdateServiceDTO UpdateServiceDTO);
	}
}
