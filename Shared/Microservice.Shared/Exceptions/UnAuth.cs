using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Shared.Exceptions
{
    public class UnAuth:Exception
    {
        public UnAuth() : base("Oturum İşleminde Bir Hata Oluştu")
        {

        }
        public UnAuth(string Message) : base(Message)
        {

        }
    }
}
