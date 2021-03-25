using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _entityManager;

        public CarsController(ICarService entityManager)
        {
            _entityManager = entityManager;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _entityManager.GetCarDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getcarbybrand")]
        public IActionResult GetCarByBrand(string brandName)
        {
            var result = _entityManager.GetCarByBrand(brandName);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getcarbycolor")]
        public IActionResult GetCarByColor(string colorName)
        {
            var result = _entityManager.GetCarByColor(colorName);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getcarbybrandcolor")]
        public IActionResult GetCarByBrandColor(string brandName, string colorName)
        {
            var result = _entityManager.GetCarByBrandColor(brandName, colorName);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _entityManager.GetCarDetail(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getcarbyid")]
        public IActionResult GetCarById(int id)
        {
            var result = _entityManager.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _entityManager.Add(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Car car)
        {
            var result = _entityManager.Update(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("delete")]
        public IActionResult Delete(int id)
        {
            var result = _entityManager.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
