using ApiClientBase;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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
