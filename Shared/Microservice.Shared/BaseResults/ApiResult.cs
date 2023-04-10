using System;
namespace Microservice.Shared.BaseResults
{
	public class ApiResult<T>
	{
        public ApiResult(
          T? _Data,
          int _PageSize = 0,
          int _PageCount = 0,
          string? _Message = null
          )
        {
            Data= _Data;
            ResultDate = DateTime.Now;
            Message = _Message;
            PageSize = _PageSize;
            PageCount = _PageCount;
        }

        public DateTime ResultDate { get; set; }

        public T? Data { get; set; }

        public int PageSize { get; set; }

        public int PageCount { get; set; }

        public string? Message { get; set; }

    }
}

