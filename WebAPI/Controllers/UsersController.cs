using Business.Abstract;
using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.DTOs;
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
    public class UsersController : ControllerBase
    {
        IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _userService.GetByIdDto(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _userService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getallmanager")]
        public IActionResult GetAllForManager()
        {
            var result = _userService.GetAllForManager();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("blockuser")]
        public IActionResult BlockUser(int id)
        {
            var result = _userService.BlockingUser(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("removeblockuser")]
        public IActionResult RemoveBlockUser(int id)
        {
            var result = _userService.RemoveBlockingUser(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(UserForRegisterDto userForRegisterDto)
        {
            var result = _userService.Update(userForRegisterDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
