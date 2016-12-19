﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApiClientIntegrationTests
{
	[TestClass]
	public class ApiClientIntegrationTests
	{
		[TestMethod]
		public void TestMethod1()
		{
			var p = ApiClientFactory.ApiClientFactory.GetApiClient("TestApiClient");
			p.Execute01();
			p.Execute02();
			p.Execute03();
		}
	}
}
