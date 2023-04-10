using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservice.Shared.BaseResults;
using Microservices.Services.Catolog.Dtos.CourseModels;
using Microservices.Services.Catolog.Models.Courses;
using Microservices.Services.Catolog.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Microservices.Services.Catolog.Controllers
{
    [Route("api/[controller]")]
    public class CourseController : BaseController
    {
        private readonly ICouseService cs;

        public CourseController(ICouseService _cs)
        {
            cs = _cs;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                //base service yazılıp sayfalama metdoları yapılabilirdi yada birleşebilirdi
                return Ok(new ApiResult<List<CourseDto>>(_Data: await cs.GetAllCourse()));
            }
            catch (Exception ex)
            {
                return ErrorHadling(ex);
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                return Ok(new ApiResult<CourseDto>(_Data: await cs.GetCorseByID(id)));
            }
            catch (Exception ex)
            {
                return ErrorHadling(ex);
            }
        }
        [HttpGet("GetByUserId/{userId}")]
        public async Task<IActionResult> GetByUserId(string userId)
        {
            try
            {
                return Ok(new ApiResult<List<CourseDto>>(_Data: await cs.GetByUserId(userId)));
            }
            catch (Exception ex)
            {
                return ErrorHadling(ex);
            }
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post(CourseCreateDto model)
        {
            try
            {
                return Ok(new ApiResult<string>(_Data: (await cs.AddCourse(model)).Id,_Message:"Kayıt Başarılı"));
            }
            catch (Exception ex)
            {
                return ErrorHadling(ex);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(CourseCreateDto model)
        {
            try
            {
                await cs.UpdateCourse(model);
                return Ok(new ApiResult<int>(_Data:1, _Message: "Güncellme Başarılı"));
            }
            catch (Exception ex)
            {
                return ErrorHadling(ex);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await cs.DeleteCourse(id);
                return Ok(new ApiResult<int>(_Data: 1, _Message: "Silme Başarılı"));
            }
            catch (Exception ex)
            {
                return ErrorHadling(ex);
            }
        }
    }
}

