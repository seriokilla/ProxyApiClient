using ApiClientBase;
using System;
using System.Diagnostics;

namespace ApiClientFactory
{
	public static class ApiClientFactory
	{
		public static IApiClient GetApiClient(string apiClientType)
		{
			switch (apiClientType)
			{
				case "TestApiClient":
					return new TestApiClient.ApiClientTest(() => Debug.WriteLine(string.Format("TestApiClient::{0}", Helper.GetCurrentMethod())));
				case "RealApiClient":
					return new RealApiClient.ApiClientReal(() => Debug.WriteLine(string.Format("RealApiClient::{0}", Helper.GetCurrentMethod())));
				default:
					throw new Exception("Unknown ApiClientType: " + apiClientType);
			}
		}
    }
}
