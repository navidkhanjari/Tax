using CoreLayer.Utilities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace UI.Areas.Admin.Controllers
{
	[Area("Admin")]
	//[Authorize]
	public class BaseController : Controller
	{
		#region (Sweet Alert)
		#region (Success)
		protected void SuccessAlert()
		{
			var Model = JsonConvert.SerializeObject(JsonAlertType.Success());

			HttpContext.Response.Cookies.Append("SystemAlert", Model);
		}
		protected void SuccessAlert(string Message)
		{
			var Model = JsonConvert.SerializeObject(JsonAlertType.Success(Message));

			HttpContext.Response.Cookies.Append("SystemAlert", Model);
		}
		#endregion

		#region (Info)
		protected void InfoAlert()
		{
			var Model = JsonConvert.SerializeObject(JsonAlertType.Info());

			HttpContext.Response.Cookies.Append("SystemAlert", Model);
		}
		protected void InfoAlert(string Message)
		{
			var Model = JsonConvert.SerializeObject(JsonAlertType.Info(Message));

			HttpContext.Response.Cookies.Append("SystemAlert", Model);
		}
		#endregion

		#region (Error)
		protected void ErrorAlert()
		{
			var Model = JsonConvert.SerializeObject(JsonAlertType.Error());

			HttpContext.Response.Cookies.Append("SystemAlert", Model);
		}
		protected void ErrorAlert(string Message)
		{
			var Model = JsonConvert.SerializeObject(JsonAlertType.Error(Message));

			HttpContext.Response.Cookies.Append("SystemAlert", Model);
		}
		#endregion
		#endregion
	}
}
