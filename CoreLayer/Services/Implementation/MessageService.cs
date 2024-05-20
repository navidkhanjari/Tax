using AutoMapper;
using CoreLayer.DTOs.Messages;
using CoreLayer.Services.Interfaces;
using CoreLayer.Software;
using DataLayer.Entities.Messages;
using Microsoft.EntityFrameworkCore;
using NakShop.Data.Context;
using System.Reflection;

namespace CoreLayer.Services.Implementation
{
	public class MessageService : IMessageService
	{
		#region (Dependency Injection)
		private readonly ApplicationContext _Context;
		private readonly IMapper _Mapper;
		public MessageService(ApplicationContext Context, IMapper Mapper)
		{
			this._Context = Context;
			this._Mapper = Mapper;
		}
		#endregion

		#region (Get Messages)
		public async Task<List<MessagesDTO>> GetMessages()
		{
			try
			{
				List<Message> Messages = await _Context.Messages.OrderByDescending(M => M.CreateDate).ToListAsync();

				List<MessagesDTO> MessageDTO = _Mapper.Map<List<Message>, List<MessagesDTO>>(Messages);

				return MessageDTO;
			}
			catch (Exception Exception)
			{
				Log.AddError(MethodBase.GetCurrentMethod(), LogType.Error, Exception.Message);

				return null;
			}
		}
		#endregion

		#region (Get Message By Id)
		public async Task<Message> GetMessageById(int Id)
		{
			try
			{
				Message Message = await _Context.Messages.SingleOrDefaultAsync(M => M.Id == Id);

				return Message;
			}
			catch (Exception Exception)
			{
				Log.AddError(MethodBase.GetCurrentMethod(), LogType.Error, Exception.Message);

				return null;
			}
		}
		#endregion


		#region (Add)
		public async Task<bool> Add(Message Message)
		{
			try
			{
				await _Context.Messages.AddAsync(Message);

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
		public async Task<bool> Delete(Message Message)
		{
			try
			{
				_Context.Messages.Remove(Message);

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


		#region (Create Message)
		public async Task<CreateMessageResult> CreateMessage(CreateMessageDTO CreateMessageDTO)
		{
			try
			{
				Message Message = _Mapper.Map<Message>(CreateMessageDTO);

				Message.CreateDate = DateTime.Now;

				await Add(Message);

				return CreateMessageResult.Success;
			}
			catch (Exception Exception)
			{
				Log.AddError(MethodBase.GetCurrentMethod(), LogType.Error, Exception.Message);

				return CreateMessageResult.Error;
			}
		}
		#endregion
	}
}
