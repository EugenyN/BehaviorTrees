// Copyright(c) 2015 Eugeny Novikov. Code under MIT license.

using System.Diagnostics;

namespace BehaviorTrees.Utils
{
	public static class Log
	{
		public static readonly object[] NullFormatArgs = null;

		public static void Write(string message, params object[] messageFormatArgs)
		{
			Write(null, message, messageFormatArgs);
		}

		public static void Write(string message)
		{
			Write(null, message, NullFormatArgs);
		}

		public static void Write(Exception ex)
		{
			Write(ex, null, NullFormatArgs);
		}

		public static void Write(Exception ex, string message)
		{
			Write(ex, message, NullFormatArgs);
		}

		public static void Write(Exception ex, string message, params object[] messageFormatArgs)
		{
			Trace.WriteLine(Format(ex, message, messageFormatArgs));
		}

		private static string Format(Exception ex, string message, params object[] messageFormatArgs)
		{
			try
			{
				if (string.IsNullOrEmpty(message))
				{
					if (ex == null)
						return null;
					message = "Exception occurred: " + ex;
				}
				else
				{
					if (messageFormatArgs != null && messageFormatArgs.Length > 0)
					{
						for (int i = 0; i < messageFormatArgs.Length; i++)
						{
							if (messageFormatArgs[i] == null)
								messageFormatArgs[i] = string.Empty;
						}
						message = string.Format(message, messageFormatArgs);
					}

					if (ex != null)
						message += ". Exception: " + ex;
				}
			}
			catch (Exception)
			{
				if (string.IsNullOrEmpty(message))
					return null;
			}

			return message;
		}
	}
}