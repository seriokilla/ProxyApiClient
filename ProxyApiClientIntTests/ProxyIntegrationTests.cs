using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProxyApiClientTests
{
	[TestClass]
	public class ProxyIntegrationTests
	{
		[TestMethod]
		public void TestMethod1()
		{
            var client = ApiClientFactory.Factory.GetApiClient();

            client.Execute01();
            client.Execute02();
            client.Execute03();

        }
	}
}
