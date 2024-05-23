using CoreLayer.DTOs.Comments;
using CoreLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace UI.ViewComponents
{
    public class CommentsViewComponent : ViewComponent
    {
        private readonly ICommentService _CommentService;

        public CommentsViewComponent(ICommentService CommentService)
        {
            this._CommentService = CommentService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<CommentsDTO> CommentsDTOs = await _CommentService.GetCommentsForShow();

            return View("Comments", CommentsDTOs);
        }
    }
}

