using CoreLayer.DTOs.User;
using DataLayer.Entities.Users;

namespace CoreLayer.Services.Interfaces
{
	public interface IUserService
	{
		Task<User> LoginUser(LoginUserDTO LoginUserDTO);
	}
}
