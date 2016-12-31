using ApiClientBase;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace TestApiClient
{
	public class ApiClientTest : IApiClient
	{
		private Action LogLine;

		public ApiClientTest(Action logLine)
		{
			LogLine = logLine;
		}
		public void Execute01(int i=0)
		{
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
