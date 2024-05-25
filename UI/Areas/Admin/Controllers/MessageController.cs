using AutoMapper;
using CoreLayer.DTOs.Messages;
using CoreLayer.Services.Interfaces;
using DataLayer.Entities.Messages;
using Microsoft.AspNetCore.Mvc;

namespace UI.Areas.Admin.Controllers
{
	public class MessageController : BaseController
	{
		#region (Dependency injection)
		private readonly IMessageService _MessageService;
		private readonly IMapper _Mapper;
		public MessageController(IMessageService MessageService, IMapper Mapper)
		{
			_MessageService = MessageService;
			_Mapper = Mapper;
		}

		#endregion

		#region (Index)
		[HttpGet("Admin/Messages")]
		public async Task<IActionResult> Index()
		{
			List<MessagesDTO> MessagesDTO = await _MessageService.GetMessages();

			return View(MessagesDTO);
		}
		#endregion

		#region (Detail)
		#region (Get)
		[HttpGet("Admin/Messages/Detail/{Id}")]
		public async Task<IActionResult> DetailMessage(int Id)
		{
			Message Message = await _MessageService.GetMessageById(Id);

			if (Message == null)
			{
				return NotFound();
			}

			_MessageService.ReadMessage(Message);

			MessagesDTO MessagesDTO = _Mapper.Map<MessagesDTO>(Message);

			return View("Detail", MessagesDTO);
		}
		#endregion
		#endregion

		#region (Delete)
		#region (Post)
		[HttpPost("Admin/Messages/Delete/{Id}")]
		public async Task<IActionResult> DeleteService(int Id)
		{
			Message Message = await _MessageService.GetMessageById(Id);

			if (Message == null)
			{
				return NotFound();
			}

			bool Result = await _MessageService.Delete(Message);

			if (Result)
			{
				SuccessAlert();
			}
			else
			{
				ErrorAlert();
			}

			return RedirectToAction("Index");
		}
		#endregion
		#endregion

	}
}
