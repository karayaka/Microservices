using System;
using AutoMapper;
using MassTransit;
using Microservice.Shared.Exceptions;
using Microservice.Shared.Messages;
using Microservices.Services.Catolog.Configs;
using Microservices.Services.Catolog.Dtos.CourseModels;
using Microservices.Services.Catolog.Models.Courses;
using Microservices.Services.Catolog.Models.Definations;
using MongoDB.Driver;

namespace Microservices.Services.Catolog.Services
{
	public class CourseService: ICouseService
    {
        private readonly IMongoCollection<Course> _courseColletion;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoind;

        public CourseService(
            ICategoryService categoryService,
            IMapper mapper,
            IPublishEndpoint publishEndpoind,
            DatabaseSetting setting)
		{
            var cliend = new MongoClient(setting.ConnectionString);
            var database = cliend.GetDatabase(setting.DatabaseName);
            _courseColletion = database.GetCollection<Course>(
                setting.CourseCollectionName);
            _mapper = mapper;
            _categoryService = categoryService;
            _publishEndpoind = publishEndpoind;
        }

        public async Task<List<CourseDto>> GetAllCourse()
        {
            try
            {
                var courses = _mapper.Map<List<CourseDto>>(
                    await (await _courseColletion.FindAsync<Course>(t => true)).ToListAsync());
                if (courses == null)
                    throw new CusEx("KursBulunbamadı", Code: 404);
                foreach (var course in courses)
                {
                    course.Category = await _categoryService.GetByID(course.CategoryId);
                }
                return courses;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CourseDto> GetCorseByID(string id)
        {
            try
            {
                var course = _mapper.Map<CourseDto>((await _courseColletion.FindAsync(t => t.Id == id)).FirstOrDefault());
                if (course == null)
                    throw new CusEx("Kurs Bulunamadı", Code: 404);
                course.Category = await _categoryService.GetByID(course.CategoryId);
                return course;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<CourseDto>> GetByUserId(string userId)
        {
            try
            {
                var courses = _mapper.Map<List<CourseDto>>((await _courseColletion.FindAsync(t => t.CreatedUserId == userId)).ToList());
                if (courses == null)
                    throw new CusEx("Kurs Bulunamadı", Code: 404);
                foreach (var course in courses)
                {
                    course.Category = await _categoryService.GetByID(course.CategoryId);
                }
                return courses;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Course> AddCourse(CourseCreateDto model)
        {
            try
            {
                var course = _mapper.Map<Course>(model);
                await _courseColletion.InsertOneAsync(course);

                return course;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task UpdateCourse(CourseCreateDto model)
        {
            try
            {

                var course = await (await _courseColletion.FindAsync(t => t.Id == model.Id)).FirstOrDefaultAsync();

                var updatedCourse = _mapper.Map<CourseCreateDto, Course>(model, course);

                var result= await _courseColletion.FindOneAndReplaceAsync(t => t.Id == model.Id, updatedCourse);
                if (result == null)
                    throw new CusEx("Güncellenecek kurs bulunamadı", Code: 404);

                await _publishEndpoind.Publish<CourseNameChangeEvent>(new CourseNameChangeEvent()
                {
                    CourseId=updatedCourse.Id,
                    UpdatedName=updatedCourse.Name,
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task DeleteCourse(string id)
        {
            try
            {
                var course= _courseColletion.FindOneAndDelete(c => c.Id == id);
                if (course == null)
                    throw new CusEx("Kurs Bulunamadı", Code: 404);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
	}
}

