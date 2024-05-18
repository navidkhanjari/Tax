using System.Globalization;

namespace CoreLayer.Utilities
{
	public static class Extentions
	{
		public static string ToShamsi(this DateTime value)
		{
			PersianCalendar PersianCalendar = new PersianCalendar();

			return PersianCalendar.GetYear(value) + "/" + PersianCalendar.GetMonth(value).ToString("00") + "/" + PersianCalendar.GetDayOfMonth(value).ToString("00");
		}
	}
}
