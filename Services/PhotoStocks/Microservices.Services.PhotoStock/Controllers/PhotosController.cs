using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservice.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Microservices.Services.PhotoStock.Controllers
{
    [Route("api/[controller]")]
    public class PhotosController : Controller
    {
        // POST api/values
        [HttpPost]
        public async Task<IActionResult> SavePhotos(IFormFile photo, CancellationToken cancellationToken)
        {
            try
            {

                if (photo != null && photo.Length > 0)
                {
                    var guid = Guid.NewGuid();
                    var path = Path.Combine("wwwroot", "Photos", guid + photo.FileName);
                    using var strm = new FileStream(path, FileMode.Create);
                    await photo.CopyToAsync(strm, cancellationToken);
                    return Ok(new ResponseDto<string>(path));//burda full path dönmeli mi 
                }
                else
                    return BadRequest("Fotograf Kayıt Edielemdi");


            }
            catch (Exception)
            {
                return BadRequest("Bir Hata Oluştu");
            }
        }

        [HttpDelete("{path}")]
        public IActionResult DeletePhoto(string path)
        {
            try
            {
                if (!System.IO.File.Exists(path))
                {
                    return NotFound("Resim Bulunamdı");
                }
                System.IO.File.Delete(path);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Bir Hata Oluştu");
            }
        }
    }
}

