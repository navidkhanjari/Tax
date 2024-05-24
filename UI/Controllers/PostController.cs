using CoreLayer.DTOs.Filter;
using CoreLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class PostController : BaseController
    {
        private readonly IPostService _PostService;
        public PostController(IPostService PostService)
        {
            this._PostService = PostService;
        }

        [HttpGet("blog")]
        public IActionResult Index(PostFilterForShowDTO PostFilterForShowDTO)
        {
            return View(_PostService.GetPostByFilterForShow(PostFilterForShowDTO));
        }
    }
}
