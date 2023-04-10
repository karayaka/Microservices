using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservice.Shared.Exceptions;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Microservices.Services.Catolog.Controllers
{
    public class BaseController : Controller
    {
        // GET: /<controller>/
        protected IActionResult ErrorHadling(Exception ex)
        {
            if (ex is UnAuth)
                return Unauthorized(ex.Message);
            if (ex is CusEx)
                return BadRequest(ex.Message);
            else
                return BadRequest("Beklenmeyen Bir Hata Oluştu");
        }
    }
}

