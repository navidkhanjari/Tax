using Microsoft.AspNetCore.Mvc;

namespace UI.ViewComponents
{
	public class MainSliderViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View("MainSlider");
		}
	}
}
