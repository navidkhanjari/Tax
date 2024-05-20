using DataLayer.Entities.Users;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using CoreLayer.Services.Interfaces;
using CoreLayer.DTOs.User;

namespace UI.Controllers
{
	public class HomeController : Controller
	{
		#region (Field)
		public string ReturnUrl { get; set; }
		#endregion

		#region (Dependency Injection)
		private readonly IUserService _UserService;
		public HomeController(IUserService UserService)
		{
			this._UserService = UserService;
		}
		#endregion

		#region (Index)
		public IActionResult Index()
		{
			return View();
		}
		#endregion

		#region (Login)
		#region (Get)
		[HttpGet("Admin/login")]
		public IActionResult Login()
		{
			if (this.User.Identity.IsAuthenticated)
			{
				return Redirect("/");
			}

			return View();
		}
		#endregion

		#region (Post)
		[HttpPost("Admin/login"), ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(LoginUserDTO LoginUserDTO, string ReturnUrl = null)
		{
			if (!ModelState.IsValid)
			{
				#region (Client Side Error)
				return View(LoginUserDTO);
				#endregion
			}

			this.ReturnUrl = ReturnUrl;

			User User = await _UserService.LoginUser(LoginUserDTO);

			if (User != null)
			{
				#region (Cookie)
				var Claims = new List<Claim> { new Claim(ClaimTypes.NameIdentifier, User.Id.ToString()), new Claim(ClaimTypes.Name, $"{User.FirstName} {User.LastName}") };

				var Identity = new ClaimsIdentity(Claims, CookieAuthenticationDefaults.AuthenticationScheme);
				var Principal = new ClaimsPrincipal(Identity);
				var Properties = new AuthenticationProperties
				{
					IsPersistent = true,
				};

				await HttpContext.SignInAsync(Principal, Properties);
				#endregion

				if (!string.IsNullOrEmpty(this.ReturnUrl))
				{
					return Redirect(this.ReturnUrl);
				}

				return RedirectToAction("Admin");
			}

			ModelState.AddModelError("UserName", "نام کاربری یا کلمه عبور اشتباه است!");

			return View(User);
		}
		#endregion
		#endregion
	}
}
