using CoreLayer.DTOs.User;
using CoreLayer.Services.Interfaces;
using CoreLayer.Software;
using DataLayer.Entities.Users;
using Microsoft.EntityFrameworkCore;
using DataLayer.Context;
using System.Reflection;
using CoreLayer.Utilities.Security;

namespace CoreLayer.Services.Implementation
{
	public class UserService : IUserService
	{
		private readonly ApplicationContext _Context;
		public UserService(ApplicationContext Context)
		{
			this._Context = Context;
		}

		public async Task<User> LoginUser(LoginUserDTO LoginUserDTO)
		{
			try
			{
				string HashPassword = Hash.EncodeToMd5(LoginUserDTO.Password);

				User User = await _Context.Users.SingleOrDefaultAsync(U => U.UserName == LoginUserDTO.UserName && U.Password == HashPassword);

				if (User != null)
				{
					return User;
				}

				return null;
			}
			catch (Exception Exception)
			{
				Log.AddError(MethodBase.GetCurrentMethod(), LogType.Error, Exception.Message);

				return null;
			}
		}
	}
}
