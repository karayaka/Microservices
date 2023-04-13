using Microservice.Shared.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Microservices.Services.PhotoStock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> SavePhotos(IFormFile photo,CancellationToken cancellationToken) 
        {
            try
            {

                if (photo != null && photo.Length > 0)
                {
                    var guid = Guid.NewGuid();
                    var path = Path.Combine("wwwroot","Photos", guid+photo.FileName);
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
