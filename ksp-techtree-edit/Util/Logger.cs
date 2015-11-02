using System;
using System.IO;

namespace ksp_techtree_edit.Util
{
	internal static class Logger
	{
		private static void Print(
			string message,
			string prefix,
			params object[] parameters)
		{
			message = String.Format(message, parameters);
			message = String.Format(
			                        "[{0}][{1}] - {2}",
			                        DateTime.Now,
			                        prefix,
			                        message);
			message += Environment.NewLine;
			File.AppendAllText("output.log", message);
		}

		public static void Error(string message, params object[] parameters)
		{
			Print(message, "ERROR", parameters);
		}

		public static void Log(string message, params object[] parameters)
		{
			Print(message, "INFO", parameters);
		}
	}
}
