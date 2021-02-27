using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;
        public static IWebHostEnvironment _webHostEnvironment;

        public CarImagesController(ICarImageService carImageService, IWebHostEnvironment webHostEnvironment)
        {
            _carImageService = carImageService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm(Name = ("files"))] IFormFile image, [FromForm] CarImage carImage)
        {
            string path = _webHostEnvironment.WebRootPath + "\\uploads\\";
            var newGuidPath = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            using (FileStream fileStream = System.IO.File.Create(path + newGuidPath))
            {
                image.CopyTo(fileStream);
                fileStream.Flush();
                carImage.ImagePath = path + newGuidPath;
                var result = _carImageService.Add(carImage);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
        }

        [HttpGet("delete")]
        public IActionResult Delete(int id)
        {
            var result = _carImageService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm(Name = ("files"))] IFormFile image, [FromForm] CarImage carImage)
        {
            string path = _webHostEnvironment.WebRootPath + "\\uploads\\";
            var newGuidPath = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            using (FileStream fileStream = System.IO.File.Create(path + newGuidPath))
            {
                image.CopyTo(fileStream);
                fileStream.Flush();
                carImage.ImagePath = path + newGuidPath;
                var result = _carImageService.Update(carImage);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
        }

        [HttpGet("getcarimage")]
        public IActionResult GetCarImage(int carId)
        {
            var result = _carImageService.GetCarImage(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
            
        }
    }
}
