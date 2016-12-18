using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProxyApiClientTests
{
	[TestClass]
	public class ProxyTests
	{
		[TestMethod]
		public void TestMethod1()
		{
			var p = new ProxyApiClient.ProxyApiClient();
			p.CallMethod01();
			p.CallMethod02();
			p.CallMethod03();
		}
	}
}
