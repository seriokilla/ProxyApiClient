using ApiClientBase;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace RealApiClient
{
	public class ApiClientReal : IApiClient
	{
		private Action LogLine;
		public ApiClientReal(Action logLine)
		{
			LogLine = logLine;
		}
		public void Execute01(int i = 0)
		{
			if (i == 1)
				return;
			else
				LogLine();
		}

		public void Execute02()
		{
			LogLine();
		}

		public void Execute03()
		{
			LogLine();
		}
	}
}
