using DataLayer.Entities.Users;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using CoreLayer.Services.Interfaces;
using CoreLayer.DTOs.User;
using CoreLayer.DTOs.ContactUs;
using CoreLayer.DTOs.Messages;
using CoreLayer.DTOs.AboutUs;

namespace UI.Controllers
{
	public class HomeController : BaseController
	{
		#region (Field)
		public string ReturnUrl { get; set; }
		#endregion

		#region (Dependency Injection)
		private readonly IUserService _UserService;
		private readonly IContactUsService _ContactUsService;
		private readonly IMessageService _MessageService;
		private readonly IAboutUsService _AboutUsService;
		public HomeController(IUserService UserService, IContactUsService ContactUsService, IMessageService MessageService, IAboutUsService AboutUsService)
		{
			this._UserService = UserService;
			this._ContactUsService = ContactUsService;
			this._MessageService = MessageService;
			this._AboutUsService = AboutUsService;
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

		#region (Contact Us)
		#region (Get)
		[HttpGet("contact-us")]
		public async Task<IActionResult> ContactUs()
		{
			ContactUsDTO ContactUsDTO = await _ContactUsService.GetContactUs();

			return View(ContactUsDTO);
		}
		#endregion

		#region (Post)
		[HttpPost("contact-us")]
		public async Task<IActionResult> ContactUs(CreateMessageDTO CreateMessageDTO)
		{
			CreateMessageResult Result = await _MessageService.CreateMessage(CreateMessageDTO);

			switch (Result)
			{
				case CreateMessageResult.Success:
					SuccessAlert("پیام شما ارسال شد");

					// Send Email To Admin

					break;
				case CreateMessageResult.Error:
					ErrorAlert();
					break;
			}

			return RedirectToAction("ContactUs");
		}
		#endregion
		#endregion

		#region (About Us)
		#region (Get)
		[HttpGet("about-us")]
		public async Task<IActionResult> AboutUs()
		{
			AboutUsDTO AboutUsDTO = await _AboutUsService.GetAboutUs();

			return View(AboutUsDTO);
		}
		#endregion
		#endregion

		#region (Services)
		#region (Get)
		[HttpGet("services")]
		public IActionResult Services()
		{
			return View();
		}
		#endregion
		#endregion
	}
}
