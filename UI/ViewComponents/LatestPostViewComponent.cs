using CoreLayer.DTOs.Posts;
using CoreLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace UI.ViewComponents
{
	public class LatestPostViewComponent : ViewComponent
	{
		private readonly IPostService _PostService;
		public LatestPostViewComponent(IPostService PostService)
		{
			this._PostService = PostService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			List<PostDTO> PostDTOs = await _PostService.GetPostsForShow(5);

			return View("LatestPost", PostDTOs);
		}
	}
}

