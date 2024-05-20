using AutoMapper;
using CoreLayer.DTOs.Comments;
using DataLayer.Entities.Comments;
using CoreLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace UI.Areas.Admin.Controllers
{
	public class CommentController : BaseController
	{
		#region (Dependency injection)
		private readonly ICommentService _CommentService;
		private readonly IMapper _Mapper;
		public CommentController(ICommentService CommentService, IMapper Mapper)
		{
			_CommentService = CommentService;
			_Mapper = Mapper;
		}
		#endregion

		#region (Index)
		[HttpGet("Admin/Comments")]
		public async Task<IActionResult> Index()
		{
			List<CommentsDTO> CommentsDTO = await _CommentService.GetComments();

			return View(CommentsDTO);
		}
		#endregion

		#region (Create)
		#region (Get)
		[HttpGet("Admin/Comments/Create")]
		public IActionResult CreateComment()
		{
			return View();
		}
		#endregion

		#region (Post)
		[HttpPost("Admin/Comments/Create")]
		public async Task<IActionResult> CreateComment(CreateCommentDTO CreateCommentDTO)
		{
			if (!ModelState.IsValid)
			{
				#region (Client Side Error)
				return View(CreateCommentDTO);
				#endregion
			}

			CreateCommentResult Result = await _CommentService.CreateComment(CreateCommentDTO);

			switch (Result)
			{
				case CreateCommentResult.Success:
					SuccessAlert();
					return RedirectToAction("Index");
				case CreateCommentResult.Error:
					ErrorAlert();
					break;
			}

			return View(CreateCommentDTO);
		}
		#endregion
		#endregion

		#region (Update)
		#region (Get)
		[HttpGet("Admin/Comment/Update/{Id}")]
		public async Task<IActionResult> UpdateComment(int Id)
		{
			Comment Comment = await _CommentService.GetCommentById(Id);

			if (Comment == null)
			{
				return NotFound();
			}

			UpdateCommentDTO UpdateCommentDTO = _Mapper.Map<UpdateCommentDTO>(Comment);

			return View(UpdateCommentDTO);
		}
		#endregion

		#region (Post)
		[HttpPost("Admin/Comment/Update/{Id}")]
		public async Task<IActionResult> UpdateComment(UpdateCommentDTO UpdateCommentDTO)
		{
			if (!ModelState.IsValid)
			{
				#region (Client Side Error)
				return View(UpdateCommentDTO);
				#endregion
			}

			UpdateCommentResult Result = await _CommentService.UpdateComment(UpdateCommentDTO);

			switch (Result)
			{
				case UpdateCommentResult.Success:
					SuccessAlert();

					return RedirectToAction("Index");
				case UpdateCommentResult.Error:
					ErrorAlert();
					break;
			}

			return View(UpdateCommentDTO);
		}
		#endregion
		#endregion

		#region (Delete)
		#region (Post)
		[HttpPost("Admin/Comments/Delete/{Id}")]
		public async Task<IActionResult> DeleteComment(int Id)
		{
			Comment Comment = await _CommentService.GetCommentById(Id);

			if (Comment == null)
			{
				return NotFound();
			}

			bool Result = await _CommentService.Delete(Comment);

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
		[HttpGet("Admin/Comments/Detail/{Id}")]
		public async Task<IActionResult> DetailComment(int Id)
		{
			Comment Comment = await _CommentService.GetCommentById(Id);

			if (Comment == null)
			{
				return NotFound();
			}

			CommentsDTO CommentDTO = _Mapper.Map<CommentsDTO>(Comment);

			return View(CommentDTO);
		}
		#endregion
		#endregion
	}
}
