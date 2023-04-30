﻿using System;
namespace Microservice.Order.Application.Dtos
{
	public class AdressDto
	{
		public AdressDto()
		{
		}
        public string Province { get; set; }

        public string District { get; set; }

        public string Street { get; set; }

        public string ZipCode { get; set; }

        public string Line { get; set; }
    }
}

