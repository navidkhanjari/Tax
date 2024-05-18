using Microsoft.AspNetCore.Http;

namespace CoreLayer.Utilities
{
	public static class UploadImage
	{
		public static void AddImageToServer(this IFormFile Image, string FileName, string OrginalPath, string? DeleteFileName = null)
		{
			try
			{
				if (Image != null)
				{
					if (!Directory.Exists(OrginalPath))
						Directory.CreateDirectory(OrginalPath);

					if (!string.IsNullOrEmpty(DeleteFileName))
					{
						if (File.Exists(OrginalPath + DeleteFileName))
							File.Delete(OrginalPath + DeleteFileName);
					}

					string OriginPath = OrginalPath + FileName;

					using (var stream = new FileStream(OriginPath, FileMode.Create))
					{
						if (!Directory.Exists(OriginPath)) Image.CopyTo(stream);
					}
				}
			}
			catch { }
		}

		public static string SaveFileAndReturnName(IFormFile File, string SavePath)
		{
			if (File == null)
			{
				throw new Exception("File Is Null");
			}

			var FileName = Guid.NewGuid().ToString("N") + Path.GetExtension(File.FileName);

			File.AddImageToServer(FileName, SavePath);

			return FileName;
		}
	}
}
