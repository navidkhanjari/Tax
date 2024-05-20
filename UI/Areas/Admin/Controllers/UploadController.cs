using CoreLayer.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace UI.Areas.Admin.Controllers
{
	public class UploadController : Controller
	{
		[Route("Upload/PostContent")]
		public IActionResult PostContent(IFormFile upload)
		{
			if (upload == null)
			{
				return BadRequest();
			}

			var imageName = upload.SaveFileAndReturnName(FilePath.PostContentImageUploadPath);
			var url = FilePath.PostContentImagePath;

			return Json(new { Uploaded = true, url = url + imageName });
		}
	}
}
