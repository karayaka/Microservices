using System;
using Microservices.Services.Catolog.Dtos.CourseModels;
using Microservices.Services.Catolog.Models.Courses;

namespace Microservices.Services.Catolog.Services
{
	public interface ICouseService
	{

        Task<List<CourseDto>> GetAllCourse();

        Task<CourseDto> GetCorseByID(string id);

        Task<Course> AddCourse(CourseCreateDto model);

        Task UpdateCourse(CourseCreateDto model);

        Task DeleteCourse(string id);

        Task<List<CourseDto>> GetByUserId(string userId);


    }
}

