using System;
namespace Microservices.Services.Payment.Exceptions
{
	public class NotFoundException:Exception
	{
        public NotFoundException() : base("Öğe Buunamadı")
        {
        }
        public NotFoundException(string message) : base(message)
        {

        }
    }
}

