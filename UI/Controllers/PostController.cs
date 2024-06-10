using CoreLayer.DTOs.Filter;
using CoreLayer.DTOs.Posts;
using CoreLayer.Services.Implementation;
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

        [HttpGet("blog/{slug}")]
        public async Task<IActionResult> DetailPost(string Slug)
        {
            PostDTO PostDTO = await _PostService.GetPostBySlugForShow(Slug);

            if(PostDTO != null)
            {
                await _PostService.IncreaseVisit(Slug);
            }

            return View(PostDTO);
        }
    }
}
