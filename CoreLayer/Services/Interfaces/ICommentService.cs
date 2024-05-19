using CoreLayer.DTOs.Comments;
using DataLayer.Entities.Comments;
using DataLayer.Entities.Services;

namespace CoreLayer.Services.Interfaces
{
	public interface ICommentService
	{
		Task<List<CommentsDTO>> GetComments();
		Task<Comment> GetCommentById(int Id);

		Task<bool> Add(Comment Comment);
		Task<bool> Update(Comment Comment);
		Task<bool> Delete(Comment Comment);

		Task<CreateCommentResult> CreateComment(CreateCommentDTO CreateCommentDTO);
		Task<UpdateCommentResult> UpdateComment(UpdateCommentDTO UpdateCommentDTO);
	}
}
