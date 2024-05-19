﻿using AutoMapper;
using CoreLayer.DTOs.Comments;
using CoreLayer.Services.Interfaces;
using CoreLayer.Software;
using CoreLayer.Utilities;
using DataLayer.Entities.Comments;
using Microsoft.EntityFrameworkCore;
using NakShop.Data.Context;
using System.Reflection;

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

		#region (Get Comment By Id)
		public async Task<Comment> GetCommentById(int Id)
		{
			try
			{
				Comment Comment = await _Context.Comments.SingleOrDefaultAsync(C => C.Id == Id);

				return Comment;
			}
			catch (Exception Exception)
			{
				Log.AddError(MethodBase.GetCurrentMethod(), LogType.Error, Exception.Message);

				return null;
			}
		}
		#endregion

		#region (Get Comments)
		public async Task<List<CommentsDTO>> GetComments()
		{
			try
			{
				List<Comment> Comments = await _Context.Comments.ToListAsync();

				List<CommentsDTO> CommentsDTOs = _Mapper.Map<List<Comment>, List<CommentsDTO>>(Comments);

				return CommentsDTOs;
			}
			catch (Exception Exception)
			{
				Log.AddError(MethodBase.GetCurrentMethod(), LogType.Error, Exception.Message);

				return null;
			}
		}
		#endregion


		#region(Add)
		public async Task<bool> Add(Comment Comment)
		{
			try
			{
				await _Context.Comments.AddAsync(Comment);

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

		#region (Update)
		public async Task<bool> Update(Comment Comment)
		{
			try
			{
				_Context.Comments.Update(Comment);
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
		public async Task<bool> Delete(Comment Comment)
		{
			try
			{
				_Context.Comments.Remove(Comment);
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


		#region (Create Comment)
		public async Task<CreateCommentResult> CreateComment(CreateCommentDTO CreateCommentDTO)
		{
			try
			{
				Comment Comment = _Mapper.Map<Comment>(CreateCommentDTO);

				string ImageName = CreateCommentDTO.CustomerImage.SaveFileAndReturnName(FilePath.CommentImageUploadPath);

				Comment.CustomerImageName = ImageName;

				await Add(Comment);

				return CreateCommentResult.Success;
			}
			catch (Exception Exception)
			{
				Log.AddError(MethodBase.GetCurrentMethod(), LogType.Error, Exception.Message);

				return CreateCommentResult.Error;
			}
		}
		#endregion

		#region (Update Comment)
		public async Task<UpdateCommentResult> UpdateComment(UpdateCommentDTO UpdateCommentDTO)
		{
			try
			{
				Comment Comment = _Mapper.Map<Comment>(UpdateCommentDTO);

				if (UpdateCommentDTO.CustomerImage != null)
				{
					string ImageName = UpdateCommentDTO.CustomerImage.SaveFileAndReturnName(FilePath.CommentImageUploadPath);

					Comment.CustomerImageName = ImageName;
				}

				await Update(Comment);

				return UpdateCommentResult.Success;
			}
			catch (Exception Exception)
			{
				Log.AddError(MethodBase.GetCurrentMethod(), LogType.Error, Exception.Message);

				return UpdateCommentResult.Error;
			}
		}
		#endregion
	}
}
