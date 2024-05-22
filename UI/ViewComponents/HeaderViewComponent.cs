using Microsoft.AspNetCore.Mvc;

namespace UI.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View("Header");
		}
	}
}
