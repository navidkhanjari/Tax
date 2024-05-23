using CoreLayer.DTOs.Filter;
using CoreLayer.DTOs.Posts;
using DataLayer.Entities.Posts;

namespace CoreLayer.Services.Interfaces
{
    public interface IPostService
    {
        Task<List<Post>> GetPosts();
        Task<List<PostDTO>> GetPostsForShow(int? take = null);
        Task<Post> GetPostById(int Id);
        Task<Post> GetPostBySlug(string Slug);

        PostFilterDTO GetPostByFilter(PostFilterDTO PostFilterDTO);

        Task<bool> Add(Post Post);
        Task<bool> Update(Post Post);
        Task<bool> Delete(Post Post);

        Task<CreatePostResult> CreatePost(CreatePostDTO CreatePostDTO);
        Task<UpdatePostResult> UpdatePost(UpdatePostDTO UpdatePostDTO);
    }
}
