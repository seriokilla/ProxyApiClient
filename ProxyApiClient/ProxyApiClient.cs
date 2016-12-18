using ApiClientBase;
using Ninject;
using Ninject.Extensions.Factory;
using Ninject.Modules;
using System;
using System.Configuration;

namespace ProxyApiClient
{
	public interface IApiClientFactory
	{
		IApiClient BuildApiClient(string apiClientType);
	}

	public class ApiClientModule : NinjectModule
	{
		public override void Load()
		{
			Bind<IApiClientFactory>().ToFactory(() => new FirstArgumentAsNameInstanceProvider());
			Bind<IApiClient>().To<RealApiClient.RealApiClient>().Named("RealApiClient");
			Bind<IApiClient>().To<TestApiClient.TestApiClient>().Named("TestApiClient");
		}
	}
	
	public class FirstArgumentAsNameInstanceProvider : StandardInstanceProvider
	{
		protected override string GetName(System.Reflection.MethodInfo methodInfo, object[] arguments)
		{
			return (string)arguments[0];
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
					using (var kernel = new StandardKernel(new ApiClientModule()))
					{
						var factory = kernel.Get<IApiClientFactory>();
						_ApiClient = factory.BuildApiClient(clientType);
					}
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
