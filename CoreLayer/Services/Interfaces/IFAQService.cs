using CoreLayer.DTOs.FAQs;
using DataLayer.Entities.FAQ;
using DataLayer.Entities.Services;

namespace CoreLayer.Services.Interfaces
{
	public interface IFAQService
	{
		Task<List<FAQs>> GetFAQs();
		Task<FAQs> GetFAQbyId(int Id);

		Task<bool> Add(Service Service);
		Task<bool> Update(Service Service);

		Task<CreateFAQResult> CreateFAQ(CreateFAQDTO CreateFAQDTO);
		Task<UpdateFAQResult> UpdateFAQ(UpdateFAQDTO CreateFAQDTO);
	}
}
