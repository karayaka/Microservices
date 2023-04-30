using System;
using Microservice.Order.Domain.ValueObjects;

namespace Microservice.Order.Domain.AggregateRoots.OrderAggtregate
{
	public class Adress: ValueObject
    {
		public Adress(){}

		public Adress(string _Province,string _District, string _Street,string _ZipCode,string _Line)
		{
			Province = _Province;
			District = _District;
			Street = _Street;
			ZipCode = _ZipCode;
			Line = _Line;
		}

		public string Province { get; private set; }

		public string District { get; private set; }

		public string Street { get;private set; }

		public string ZipCode { get;private set; }

		public string Line { get;private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
			yield return Province;
			yield return District;
			yield return Street;
			yield return ZipCode;
			yield return Line;
        }
    }
}

