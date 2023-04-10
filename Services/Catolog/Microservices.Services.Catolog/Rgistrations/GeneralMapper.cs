using System;
using AutoMapper;
using Microservices.Services.Catolog.Dtos.CourseModels;
using Microservices.Services.Catolog.Dtos.DefinationModels;
using Microservices.Services.Catolog.Models.Courses;
using Microservices.Services.Catolog.Models.Definations;

namespace Microservices.Services.Catolog.Rgistrations
{
	public class GeneralMapper:Profile
	{
		public GeneralMapper()
		{
			CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<Course, CourseCreateDto>().ReverseMap();
			CreateMap<Category, CategoryDto>().ReverseMap();
			CreateMap<Feature, FeatureDto>().ReverseMap();
		}
	}
}

