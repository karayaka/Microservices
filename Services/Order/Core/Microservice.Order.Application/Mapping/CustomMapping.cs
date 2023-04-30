using System;
using AutoMapper;
using Microservice.Order.Application.Dtos;
using Microservice.Order.Domain.AggregateRoots.OrderAggtregate;

namespace Microservice.Order.Application.Mapping
{
	public class CustomMapping : Profile
	{
		public CustomMapping()
		{
			CreateMap<Order.Domain.AggregateRoots.OrderAggtregate.Order, OrderDto>().ReverseMap();
			CreateMap<OrderItem, OrderItemDto>().ReverseMap();
			CreateMap<Adress, AdressDto>().ReverseMap();
		}
	}
}

