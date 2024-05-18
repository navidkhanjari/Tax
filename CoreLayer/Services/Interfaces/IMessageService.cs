using CoreLayer.DTOs.Messages;
using DataLayer.Entities.Messages;

namespace CoreLayer.Services.Interfaces
{
	public interface IMessageService
	{
		Task<List<MessagesDTO>> GetMessages();
		Task<Message> GetMessageById(int Id);

		Task<bool> Add(Message Message);

		Task<CreateMessageResult> CreateMessage(CreateMessageDTO CreateMessageDTO);
	}
}
