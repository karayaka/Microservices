using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Shared.Exceptions
{
    public class CusEx:Exception
    {
        public int statusCode { get; set; }

        public CusEx():base("Bir Hata Oluştu")
        {

        }
        public CusEx(string Message):base(Message)
        {

        }

        public CusEx(string Message,int Code=0) : base(Message)
        {
            statusCode = Code;
        }
    }
}
