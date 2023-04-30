using System;
using AutoMapper;

namespace Microservice.Order.Application.Mapping
{
	public static class ObjectMapper
	{
		/// <summary>
		/// dependesy incection olmadan outo mapper kullanama yöntemi
		/// sadece class librry değil aynı zamanada winform applerde de işe yaraya bilir
		/// Ayrca repositoruyleride layz olarak inject edilebilir!
		/// </summary>
		private static readonly Lazy<IMapper> layz=new Lazy<IMapper>(() =>
		{
			var config = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile<CustomMapping>();
			});

			return config.CreateMapper();
		});

		public static IMapper Mapper => layz.Value;
	}
}

