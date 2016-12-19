using ApiClientBase;
using System;

namespace ApiClientFactory
{
	public static class ApiClientFactory
	{
		public static IApiClient GetApiClient(string apiClientType)
		{
			switch (apiClientType)
			{
				case "TestApiClient":
					return new TestApiClient.ApiClientTest();
				case "RealApiClient":
					return new RealApiClient.ApiClientReal();
				default:
					throw new Exception("Unknown ApiClientType: " + apiClientType);
			}
		}
    }
}
