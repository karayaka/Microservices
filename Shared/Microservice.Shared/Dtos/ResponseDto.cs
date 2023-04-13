using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Shared.Dtos
{
    public class ResponseDto<T>
    {
        public ResponseDto(T? data, string? message="")
        {
            Data = data;
            Message = message;
        }

        public T? Data { get; set; }

        public string? Message { get; set; }//data ile birlikte gösterilecek mesaj varsa diye
    }
}
