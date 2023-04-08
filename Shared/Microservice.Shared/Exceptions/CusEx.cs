using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Shared.Exceptions
{
    public class CusEx:Exception
    {
        public CusEx():base("Bir Hata Oluştu")
        {

        }
        public CusEx(string Message):base(Message)
        {

        }
    }
}
