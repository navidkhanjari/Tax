using CoreLayer.Utilities;
using System.Reflection;

namespace CoreLayer.Software
{
	public abstract class Log
	{
		#region (Methods)
		#region (Add)
		private static bool Add(MethodBase MethodBase, LogType Type, String Text)
		{
			string Date = DateTime.Now.ToShamsi();

			switch (Type)
			{
				case LogType.Warning:
					Serilog.Log.Warning($"[{Date}] - [{Type}] - {MethodBase.DeclaringType.Name} - {Text}");
					break;
				case LogType.Information:
					Serilog.Log.Information($"[{Date}] - [{Type}] - {MethodBase.DeclaringType.Name} - {Text}");
					break;
				case LogType.Error:
					Serilog.Log.Error($"[{Date}] - [{Type}] - {MethodBase.DeclaringType.Name} - {Text}");
					break;
			}

			return true;
		}
		#endregion

		#region (Add Error)
		public static bool AddError(MethodBase MethodBase, LogType Type, String Text)
		{
			return Log.Add(MethodBase, LogType.Error, Text);
		}
		#endregion

		#region (Add Information)
		public static bool AddInformation(MethodBase MethodBase, LogType Type, String Text)
		{
			return Log.Add(MethodBase, LogType.Information, Text);
		}
		#endregion

		#region (Add Warring)
		public static bool AddWarring(MethodBase MethodBase, LogType Type, String Text)
		{
			return Log.Add(MethodBase, LogType.Warning, Text);
		}
		#endregion
		#endregion
	}
}
