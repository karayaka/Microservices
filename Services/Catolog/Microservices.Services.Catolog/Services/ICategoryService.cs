using System;
using Microservices.Services.Catolog.Dtos.DefinationModels;
using Microservices.Services.Catolog.Models.Definations;

namespace Microservices.Services.Catolog.Services
{
	public interface ICategoryService
	{
        List<CategoryDto> GetCategorys();

        Task<Category> CreateCategory(CategoryDto model);

        Task<CategoryDto> GetByID(string id);

    }
}

