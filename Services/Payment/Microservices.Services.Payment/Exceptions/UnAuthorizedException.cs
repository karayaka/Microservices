using System;
namespace Microservices.Services.Payment.Exceptions
{
	public class UnAuthorizedException:Exception
	{
        public UnAuthorizedException() : base("Yetkisiz Giriş")
        {
        }
        public UnAuthorizedException(string message) : base(message)
        {

        }
    }
}

