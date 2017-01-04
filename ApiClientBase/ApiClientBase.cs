using System;

namespace ApiClientBase
{
	public interface IApiClient
    {
        ResponseData Execute01();
        ResponseData Execute02();
        ResponseData Execute03();
	}

    public class ResponseData
    {
        public int Id;
        public DateTime Date;
        public string Message;
    }
}
