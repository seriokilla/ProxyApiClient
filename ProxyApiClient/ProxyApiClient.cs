using ApiClientBase;
using System;
using System.Configuration;

namespace ProxyApiClient
{
	static class Factory
	{
		/// <summary>
		/// Decides which class to instantiate.
		/// </summary>
		public static IApiClient BuildClient(string clientType)
		{
			switch (clientType)
			{
				case "RealApiClient":
					return new RealApiClient.RealApiClient();
				case "TestApiClient":
					return new TestApiClient.TestApiClient();
				default:
					throw new Exception("Unknown IApiClient type");
			}
		}
	}
	public class ProxyApiClient
    {
		private IApiClient _ApiClient;
		public IApiClient ApiClient
		{
			get
			{
				if (_ApiClient == null)
				{
					var clientType = GetAppConfigValue("ApiClientType");
					_ApiClient = Factory.BuildClient(clientType);
				}

				return _ApiClient;
			}
			set
			{
				_ApiClient = value;
			}
		}

		private string GetAppConfigValue(string key)
		{
			try
			{
				return ConfigurationManager.AppSettings[key];
			}
			catch (ConfigurationErrorsException)
			{
				Console.WriteLine("Error reading app settings key: " + key);
				throw;
			}
		}

		public void CallMethod01()
		{
			ApiClient.Execute01();
		}

		public void CallMethod02()
		{
			ApiClient.Execute02();
		}

		public void CallMethod03()
		{
			ApiClient.Execute03();
		}
    }
}
