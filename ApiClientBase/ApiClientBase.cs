using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace ApiClientBase
{
	public interface IApiClient
    {
		void Execute01(int i=0);
		void Execute02();
		void Execute03();
	}

	public static class Helper
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static string GetCurrentMethod()
		{
			var st = new StackTrace();
			var sf = st.GetFrame(2);
			return sf.GetMethod().Name;
		}
	}
}
