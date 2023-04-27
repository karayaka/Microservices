using System;
using AutoMapper;
using Microservice.Shared.Exceptions;
using Microservices.Services.Catolog.Configs;
using Microservices.Services.Catolog.Dtos.DefinationModels;
using Microservices.Services.Catolog.Models.Definations;
using MongoDB.Driver;

namespace Microservices.Services.Catolog.Services
{
	public class CategoryService: ICategoryService
    {
		private readonly IMongoCollection<Category> _categoryColletion;
        private readonly IMapper _mapper;

        public CategoryService(
            IMapper mapper,
            DatabaseSetting setting)
        {
            var cliend = new MongoClient(setting.ConnectionString);
            var database = cliend.GetDatabase(setting.DatabaseName);
            _categoryColletion = database.GetCollection<Category>(
                setting.CategoryColletionName);
            _mapper = mapper;
        }
        public List<CategoryDto> GetCategorys()
        {
            try
            {
                var categorys = _categoryColletion.Find(t => true).ToList();
                return _mapper.Map<List<CategoryDto>>(categorys);
            }
            catch (Exception ex)
            {
                //
                throw ex;
            }
        }
        public async Task<Category> CreateCategory(CategoryDto model)
        {
            try
            {
                var category = _mapper.Map<Category>(model);
                await _categoryColletion.InsertOneAsync(category);
                return category;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        public async Task<CategoryDto> GetByID(string id)
        {
            try
            {
                var category = await (await _categoryColletion.FindAsync<Category>(t => t.Id == id)).FirstAsync();
                if (category == null)
                    throw new CusEx("Category Bulunamadı", Code: 404);
                return _mapper.Map<CategoryDto>(category); ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}

