using AutoMapper;
using CoreLayer.DTOs.Filter;
using CoreLayer.DTOs.Posts;
using CoreLayer.Services.Interfaces;
using DataLayer.Entities.Posts;
using Microsoft.AspNetCore.Mvc;

namespace UI.Areas.Admin.Controllers
{
    public class PostsController : BaseController
    {
        #region (Dependency injection)
        private readonly IPostService _PostService;
        private readonly IMapper _Mapper;
        public PostsController(IPostService PostService, IMapper Mapper)
        {
            _PostService = PostService;
            _Mapper = Mapper;
        }
        #endregion

        #region (Index)
        [HttpGet("Admin/Posts")]
        public IActionResult Index(PostFilterDTO PostFilterDTO)
        {
            return View(_PostService.GetPostByFilter(PostFilterDTO));
        }
        #endregion

        #region (Create)
        #region (Get)
        [HttpGet("Admin/Posts/Create")]
        public IActionResult CreatePost()
        {
            return View();
        }
        #endregion

        #region (Post)
        [HttpPost("Admin/Posts/Create")]
        public async Task<IActionResult> CreatePost(CreatePostDTO CreatePostDTO)
        {
            if (!ModelState.IsValid)
            {
                #region (Client Side Error)
                return View(CreatePostDTO);
                #endregion
            }

            CreatePostResult Result = await _PostService.CreatePost(CreatePostDTO);

            switch (Result)
            {
                case CreatePostResult.Success:
                    SuccessAlert();

                    return RedirectToAction("Index");
                case CreatePostResult.Error:
                    ErrorAlert();
                    break;
                case CreatePostResult.SlugExist:
                    ErrorAlert("اسلاگ تکراری است!");
                    break;
            }

            return View(CreatePostDTO);
        }
        #endregion
        #endregion

        #region (Update)
        #region (Get)
        [HttpGet("Admin/Posts/Update/{Id}")]
        public async Task<IActionResult> UpdatePost(int Id)
        {
            Post Post = await _PostService.GetPostById(Id);

            if (Post == null)
            {
                return NotFound();
            }

            UpdatePostDTO UpdatePostDTO = _Mapper.Map<UpdatePostDTO>(Post);

            return View(UpdatePostDTO);
        }
        #endregion

        #region (Post)
        [HttpPost("Admin/Posts/Update/{Id}")]
        public async Task<IActionResult> UpdatePost(UpdatePostDTO UpdatePostDTO)
        {
            if (!ModelState.IsValid)
            {
                #region (Client Side Error)
                return View(UpdatePostDTO);
                #endregion
            }

            UpdatePostResult Result = await _PostService.UpdatePost(UpdatePostDTO);

            switch (Result)
            {
                case UpdatePostResult.Success:
                    SuccessAlert();

                    return RedirectToAction("Index");
                case UpdatePostResult.Error:
                    ErrorAlert();
                    break;
                case UpdatePostResult.SlugExist:
                    ErrorAlert("اسلاگ تکراری است!");
                    break;
            }

            return View(UpdatePostDTO);
        }
        #endregion
        #endregion

        #region (Delete)
        #region (Post)
        [HttpPost("Admin/Posts/Delete/{Id}")]
        public async Task<IActionResult> DeletePost(int Id)
        {
            Post Post = await _PostService.GetPostById(Id);

            if (Post == null)
            {
                return NotFound();
            }

            bool Result = await _PostService.Delete(Post);

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
        [HttpGet("Admin/Posts/Detail/{Id}")]
        public async Task<IActionResult> DetailPost(int Id)
        {
            Post Post = await _PostService.GetPostById(Id);

            if (Post == null)
            {
                return NotFound();
            }

            PostDTO PostDTO = _Mapper.Map<PostDTO>(Post);

            return View(PostDTO);
        }
        #endregion
        #endregion
    }
}
