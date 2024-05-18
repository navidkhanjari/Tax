using CoreLayer.DTOs.Comments;
using DataLayer.Entities.Comments;
using DataLayer.Entities.Services;

namespace CoreLayer.Services.Interfaces
{
	public interface ICommentService
	{
		Task<List<CommentsDTO>> GetComments();
		Task<Comment> GetCommentById(int Id);

		Task<bool> Add(Service Service);
		Task<bool> Update(Service Service);
		Task<bool> Delete(Service Service);

		Task<CreateCommentResult> CreateComment(CreateCommentDTO CreateCommentDTO);
		Task<UpdateCommentResult> UpdateComment(UpdateCommentDTO UpdateCommentDTO);
	}
}
