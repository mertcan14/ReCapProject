using Business.Abstract;
using Core.Entities.Concrete;
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
    public class BlockedUsersController : ControllerBase
    {
        IBlockedUserService _blockedUserService;

        public BlockedUsersController(IBlockedUserService blockedUserService)
        {
            _blockedUserService = blockedUserService;
        }

        [HttpPost("add")]
        public IActionResult Add(BlockedUser blockedUser)
        {
            var result = _blockedUserService.Add(blockedUser);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(BlockedUser blockedUser)
        {
            var result = _blockedUserService.Update(blockedUser);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("delete")]
        public IActionResult Delete(int id)
        {
            var result = _blockedUserService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _blockedUserService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _blockedUserService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
