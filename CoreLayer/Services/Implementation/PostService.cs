using AutoMapper;
using CoreLayer.DTOs.Filter;
using CoreLayer.DTOs.Posts;
using CoreLayer.Services.Interfaces;
using CoreLayer.Software;
using CoreLayer.Utilities;
using DataLayer.Context;
using DataLayer.Entities.Posts;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CoreLayer.Services.Implementation
{
    public class PostService : IPostService
    {
        #region (Dependency Injection)
        private readonly ApplicationContext _Context;
        private readonly IMapper _Mapper;
        public PostService(ApplicationContext Context, IMapper Mapper)
        {
            this._Context = Context;
            this._Mapper = Mapper;
        }
        #endregion

        #region (Get Posts)
        public async Task<List<Post>> GetPosts()
        {
            try
            {
                List<Post> Post = await _Context.Posts.ToListAsync();

                return Post;
            }
            catch (Exception Exception)
            {
                Log.AddError(MethodBase.GetCurrentMethod(), LogType.Error, Exception.Message);

                return null;
            }
        }
        #endregion

        #region (Get Posts For Show)
        public async Task<List<PostDTO>> GetPostsForShow(int? Take = null)
        {
            try
            {
                if (Take != null)
                {
                    List<Post> Post = await _Context.Posts.Where(P => P.Visible).Take((int)Take).ToListAsync();

                    List<PostDTO> PostDTOs = _Mapper.Map<List<Post>, List<PostDTO>>(Post);

                    return PostDTOs;
                }
                else
                {
                    List<Post> Post = await _Context.Posts.Where(P => P.Visible).ToListAsync();

                    List<PostDTO> PostDTOs = _Mapper.Map<List<Post>, List<PostDTO>>(Post);

                    return PostDTOs;
                }
            }
            catch (Exception Exception)
            {
                Log.AddError(MethodBase.GetCurrentMethod(), LogType.Error, Exception.Message);

                return null;
            }
        }
        #endregion


        #region (Get Post By Filter)
        public PostFilterDTO GetPostByFilter(PostFilterDTO PostFilterDTO)
        {
            var Query = _Context.Posts.OrderByDescending(P => P.PublishDate).AsQueryable();

            if (PostFilterDTO.FindAll)
            {
                PostFilterDTO.Build(Query.Count()).SetEntities(Query);

                return PostFilterDTO;
            }

            if (PostFilterDTO.Title != null)
            {
                Query = Query.Where(P => P.Title.Contains(PostFilterDTO.Title));
            }

            if (PostFilterDTO.Authour != null)
            {
                Query = Query.Where(P => P.Authour.Contains(PostFilterDTO.Authour));
            }

            if (PostFilterDTO.Type != null)
            {
                switch (PostFilterDTO.Type)
                {
                    case PostFilterDTO.SearchType.MostVisited:
                        Query = Query.OrderByDescending(P => P.Visit);
                        break;
                    case PostFilterDTO.SearchType.Newest:
                        Query = Query.OrderByDescending(P => P.PublishDate);
                        break;
                    case PostFilterDTO.SearchType.Oldest:
                        Query = Query.OrderBy(P => P.PublishDate);
                        break;
                }
            }

            PostFilterDTO.Build(Query.Count()).SetEntities(Query);

            return PostFilterDTO;
        }
        #endregion

        #region (Get Post By Id)
        public async Task<Post> GetPostById(int Id)
        {
            try
            {
                Post Post = await _Context.Posts.SingleOrDefaultAsync(P => P.Id == Id);

                return Post;
            }
            catch (Exception Exception)
            {
                Log.AddError(MethodBase.GetCurrentMethod(), LogType.Error, Exception.Message);

                return null;
            }
        }
        #endregion

        #region (Get Post By Slug)
        public async Task<Post> GetPostBySlug(string Slug)
        {
            try
            {
                Post Post = await _Context.Posts.SingleOrDefaultAsync(P => P.Slug == Slug.ToSlug());

                return Post;
            }
            catch (Exception Exception)
            {
                Log.AddError(MethodBase.GetCurrentMethod(), LogType.Error, Exception.Message);

                return null;
            }
        }
        #endregion


        #region (Add)
        public async Task<bool> Add(Post Post)
        {
            try
            {
                await _Context.Posts.AddAsync(Post);
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

        #region(Update)
        public async Task<bool> Update(Post Post)
        {
            try
            {
                _Context.Posts.Update(Post);
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
        public async Task<bool> Delete(Post Post)
        {
            try
            {
                _Context.Posts.Remove(Post);
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


        #region (Create Post)
        public async Task<CreatePostResult> CreatePost(CreatePostDTO CreatePostDTO)
        {
            try
            {
                Post PostBySlug = await GetPostBySlug(CreatePostDTO.Slug);

                if (PostBySlug != null)
                {
                    return CreatePostResult.SlugExist;
                }

                Post Post = _Mapper.Map<Post>(CreatePostDTO);

                string ImageName = CreatePostDTO.Image.SaveFileAndReturnName(FilePath.PostImageUploadPath);

                Post.ImageName = ImageName;
                Post.PublishDate = DateTime.Now;
                Post.Slug = CreatePostDTO.Slug.ToSlug();

                await Add(Post);

                return CreatePostResult.Success;
            }
            catch (Exception Exception)
            {
                Log.AddError(MethodBase.GetCurrentMethod(), LogType.Error, Exception.Message);

                return CreatePostResult.Error;
            }
        }
        #endregion

        #region (Update Post)
        public async Task<UpdatePostResult> UpdatePost(UpdatePostDTO UpdatePostDTO)
        {
            try
            {
                Post PostBySlug = await GetPostBySlug(UpdatePostDTO.Slug);

                if (PostBySlug != null && PostBySlug.Id != UpdatePostDTO.Id)
                {
                    return UpdatePostResult.SlugExist;
                }

                Post Post = await GetPostById(UpdatePostDTO.Id);

                _Mapper.Map(UpdatePostDTO, Post);

                if (UpdatePostDTO.File != null)
                {
                    //delete old image
                    var ImagePath = Path.Combine(Directory.GetCurrentDirectory(), FilePath.PostImagePath, Post.ImageName);

                    if (File.Exists(ImagePath))
                    {
                        File.Delete(ImagePath);
                    }

                    string ImageName = UpdatePostDTO.File.SaveFileAndReturnName(FilePath.PostImageUploadPath);

                    Post.ImageName = ImageName;
                }

                Post.Slug = UpdatePostDTO.Slug.ToSlug();

                await Update(Post);

                return UpdatePostResult.Success;
            }
            catch (Exception Exception)
            {
                Log.AddError(MethodBase.GetCurrentMethod(), LogType.Error, Exception.Message);

                return UpdatePostResult.Error;
            }
        }
        #endregion
    }
}
