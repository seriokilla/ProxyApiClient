using ApiClientBase;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace RealApiClient
{
	public class RealApiClient : IApiClient
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		private string GetCurrentMethod()
		{
			StackTrace st = new StackTrace();
			StackFrame sf = st.GetFrame(1);

			return sf.GetMethod().Name;
		}
		public void Execute01()
		{
			Debug.WriteLine(string.Format("RealApiClient::{0}", GetCurrentMethod()));
		}

		public void Execute02()
		{
			Debug.WriteLine(string.Format("RealApiClient::{0}", GetCurrentMethod()));
		}

		public void Execute03()
		{
			Debug.WriteLine(string.Format("RealApiClient::{0}", GetCurrentMethod()));
		}
	}
}
