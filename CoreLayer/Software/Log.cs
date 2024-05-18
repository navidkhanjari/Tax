using CoreLayer.Utilities;

namespace CoreLayer.Software
{
	public abstract class Log
	{
		#region (Methods)
		#region (Add)
		private static bool Add(LogType Type, String Text)
		{
			string Date = DateTime.Now.ToShamsi();

			switch (Type)
			{
				case LogType.Warning:
					Serilog.Log.Warning($"[{Date}] - {Text}");
					break;
				case LogType.Information:
					Serilog.Log.Information($"[{Date}] - {Text}");
					break;
				case LogType.Error:
					Serilog.Log.Error($"[{Date}] - {Text}");
					break;
			}

			return true;
		}
		#endregion

		#region (Add Error)
		public static bool AddError(String Text)
		{
			return Log.Add(LogType.Error, Text);
		}
		#endregion

		#region (Add Information)
		public static bool AddInformation(String Text)
		{
			return Log.Add(LogType.Information, Text);
		}
		#endregion

		#region (Add Warring)
		public static bool AddWarring(String Text)
		{
			return Log.Add(LogType.Warning, Text);
		}
		#endregion
		#endregion
	}
}
