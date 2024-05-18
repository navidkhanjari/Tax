using CoreLayer.DTOs.Posts;
using DataLayer.Entities.Posts;

namespace CoreLayer.Services.Interfaces
{
	public interface IPostService
	{
		Task<List<Post>> GetPosts();
		Task<Post> GetPostById(int Id);

		Task<bool> Add(Post Post);
		Task<bool> Update(Post Post);
		Task<bool> Delete(Post Post);

		Task<CreatePostResult> CreatePost(CreatePostDTO CreatePostDTO);
		Task<UpdatePostResult> UpdatePost(UpdatePostDTO UpdatePostDTO);
	}
}
