using System;
using System.Diagnostics;

namespace Depra.Recovery.Exceptions
{
	internal static class Guard
	{
		[Conditional("DEBUG")]
		public static void Against(bool condition, Func<Exception> exception)
		{
			if (condition)
			{
				throw exception();
			}
		}
	}
}