using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservice.Shared.BaseResults;
using Microservices.Services.Catolog.Dtos.DefinationModels;
using Microservices.Services.Catolog.Models.Definations;
using Microservices.Services.Catolog.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Microservices.Services.Catolog.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : BaseController
    {
        private readonly ICategoryService cs;

        public CategoryController(ICategoryService cs)
        {
            this.cs = cs;
        }


        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(new ApiResult<List<CategoryDto>>(_Data: cs.GetCategorys()));
            }
            catch (Exception ex)
            {
                return ErrorHadling(ex);
            }
        }
        
        // GET api/values/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                return Ok(new ApiResult<CategoryDto>(_Data: await cs.GetByID(id)));
            }
            catch (Exception ex)
            {
                return ErrorHadling(ex);
            }
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post(CategoryDto model)
        {
            try
            {
                return Ok(new ApiResult<Category>(_Data: await cs.CreateCategory(model)));
            }
            catch (Exception ex)
            {
                return ErrorHadling(ex);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

