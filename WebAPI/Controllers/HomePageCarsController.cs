using Business.Abstract;
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
    public class HomePageCarsController : ControllerBase
    {
        IHomePageCarService _homePageCarService;

        public HomePageCarsController(IHomePageCarService homePageCarService)
        {
            _homePageCarService = homePageCarService;
        }

        [HttpPost("add")]
        public IActionResult Add(HomePageCar homePageCar)
        {
            var result = _homePageCarService.Add(homePageCar);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(HomePageCar homePageCar)
        {
            var result = _homePageCarService.Update(homePageCar);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("delete")]
        public IActionResult Delete(int id)
        {
            var result = _homePageCarService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _homePageCarService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getallmanager")]
        public IActionResult GetAllManager()
        {
            var result = _homePageCarService.GetAllManager();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getallcardetail")]
        public IActionResult GetAllCarDetail()
        {
            var result = _homePageCarService.GetAllCarDetailDto();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _homePageCarService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


    }
}
