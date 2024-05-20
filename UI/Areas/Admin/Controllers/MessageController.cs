using AutoMapper;
using CoreLayer.DTOs.Messages;
using DataLayer.Entities.Messages;
using CoreLayer.Services.Interfaces;
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

		#region (Create)
		#region (Get)
		[HttpGet("Admin/Messages/Create")]
		public IActionResult CreateMessage()
		{
			return View();
		}
		#endregion

		#region (Post)
		[HttpPost("Admin/Messages/Create")]
		public async Task<IActionResult> CreateMessage(CreateMessageDTO CreateMessageDTO)
		{
			if (!ModelState.IsValid)
			{
				#region (Client Side Error)
				return View(CreateMessageDTO);
				#endregion
			}

			CreateMessageResult Result = await _MessageService.CreateMessage(CreateMessageDTO);

			switch (Result)
			{
				case CreateMessageResult.Success:
					SuccessAlert();
					return RedirectToAction("Index");
				case CreateMessageResult.Error:
					ErrorAlert();
					break;
			}

			return View(CreateMessageDTO);
		}
		#endregion
		#endregion

		#region (Delete)
		#region (Post)
		[HttpPost("Admin/Messages/Delete/{Id}")]
		public async Task<IActionResult> DeleteMessage(int Id)
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

			MessagesDTO MessagesDTO = _Mapper.Map<MessagesDTO>(Message);

			return View(MessagesDTO);
		}
		#endregion
		#endregion
	}
}
