using CoreLayer.DTOs.FAQs;
using DataLayer.Entities.FAQ;

namespace CoreLayer.Services.Interfaces
{
	public interface IFAQService
	{
		Task<List<FAQs>> GetFAQs();
		Task<FAQs> GetFAQbyId(int Id);

		Task<bool> Add(FAQs FAQs);
		Task<bool> Update(FAQs FAQs);

		Task<CreateFAQResult> CreateFAQ(CreateFAQDTO CreateFAQDTO);
		Task<UpdateFAQResult> UpdateFAQ(UpdateFAQDTO CreateFAQDTO);
	}
}
