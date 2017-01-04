using ApiClientBase;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace TestApiClient
{
    public class TestApiClient : IApiClient
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		private string GetCurrentMethod()
		{
			StackTrace st = new StackTrace();
			StackFrame sf = st.GetFrame(1);

			return sf.GetMethod().Name;
		}
		public ResponseData Execute01()
		{
            var msg = string.Format("TestApiClient::{0}", GetCurrentMethod());
            Debug.WriteLine(msg);
            return new ResponseData { Id = 1, Date = DateTime.Now, Message = msg };
        }

		public ResponseData Execute02()
		{
            var msg = string.Format("TestApiClient::{0}", GetCurrentMethod());
            Debug.WriteLine(msg);
            return new ResponseData { Id = 2, Date = DateTime.Now, Message = msg };
        }

		public ResponseData Execute03()
		{
            var msg = string.Format("TestApiClient::{0}", GetCurrentMethod());
            Debug.WriteLine(msg);
            return new ResponseData { Id = 3, Date = DateTime.Now, Message = msg };
        }
	}
}
