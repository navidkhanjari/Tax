using Microsoft.AspNetCore.Mvc;

namespace UI.ViewComponents
{
	public class FooterViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View("Footer");
		}
	}
}
