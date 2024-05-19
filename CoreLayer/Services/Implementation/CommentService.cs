using AutoMapper;
using CoreLayer.DTOs.Comments;
using CoreLayer.Services.Interfaces;
using DataLayer.Entities.Comments;
using DataLayer.Entities.Services;
using NakShop.Data.Context;

namespace CoreLayer.Services.Implementation
{
	public class CommentService : ICommentService
	{
		#region (Dependency Injection)
		private readonly ApplicationContext _Context;
		private readonly IMapper _Mapper;
		public CommentService(ApplicationContext Context, IMapper Mapper)
		{
			this._Context = Context;
			this._Mapper = Mapper;
		}
		#endregion

		public Task<bool> Add(Service Service)
		{
			throw new NotImplementedException();
		}

		public Task<CreateCommentResult> CreateComment(CreateCommentDTO CreateCommentDTO)
		{
			throw new NotImplementedException();
		}

		public Task<bool> Delete(Service Service)
		{
			throw new NotImplementedException();
		}

		public Task<Comment> GetCommentById(int Id)
		{
			throw new NotImplementedException();
		}

		public Task<List<CommentsDTO>> GetComments()
		{
			throw new NotImplementedException();
		}

		public Task<bool> Update(Service Service)
		{
			throw new NotImplementedException();
		}

		public Task<UpdateCommentResult> UpdateComment(UpdateCommentDTO UpdateCommentDTO)
		{
			throw new NotImplementedException();
		}
	}
}
