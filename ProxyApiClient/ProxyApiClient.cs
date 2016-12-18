using ApiClientBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ProxyApiClient
{
	public enum ClientType
	{
		Unknown,
		RealApiClient,
		TestApiClient
	};

	static class Factory
	{
		/// <summary>
		/// Decides which class to instantiate.
		/// </summary>
		public static IApiClient BuildClient(ClientType clientType)
		{
			switch (clientType)
			{
				case ClientType.RealApiClient:
					return new RealApiClient.RealApiClient();
				case ClientType.TestApiClient:
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
					var clientType = ReadClientTypeSetting();
					_ApiClient = Factory.BuildClient(clientType);
				}

				return _ApiClient;
			}
			set
			{
				_ApiClient = value;
			}
		}

		private static ClientType ReadClientTypeSetting()
		{
			try
			{
				var appSettings = ConfigurationManager.AppSettings;
				var clientTypeStr = appSettings["ApiClientType"];
				var clientType = (ClientType)Enum.Parse(typeof(ClientType), clientTypeStr);
				return clientType;
			}
			catch (ConfigurationErrorsException)
			{
				Console.WriteLine("Error reading app settings");
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
