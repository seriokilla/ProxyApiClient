using ApiClientBase;
using System;
using System.Configuration;

namespace ApiClientFactory
{
	public static class Factory
	{
        public enum ApiClientType
        {
            TestApiClient,
            RealApiClient
        }

        public static IApiClient GetApiClient()
        {
            var clientTypeString = GetAppConfigValue("ApiClientType");
            return GetApiClient(clientTypeString);
        }

        public static IApiClient GetApiClient(string apiClientTypeString)
        {
            var apiClientType = (ApiClientType)Enum.Parse(typeof(ApiClientType), apiClientTypeString);
            return BuildClient(apiClientType);
        }

        private static IApiClient BuildClient(ApiClientType clientType)
        {
            switch (clientType)
            {
                case ApiClientType.RealApiClient:
                    return new RealApiClient.RealApiClient();

                case ApiClientType.TestApiClient:
                    return new TestApiClient.TestApiClient();

                default:
                    return new RealApiClient.RealApiClient();
            }
        }

        private static string GetAppConfigValue(string key)
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
    }
}
