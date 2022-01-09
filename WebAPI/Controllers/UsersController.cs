using Business.Abstract;
using Entities.Dtos;
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
        [HttpGet("getall")]
        public async Task<IActionResult> Get()
        {
            var result =await _userService.GetListAsync();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("dto")]
        public async Task<IActionResult> GetDto()
        {
            var result = await _userService.GetDtoListAsync();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("createdto")]
        public async Task<IActionResult> GetCreateDto()
        {
            var result = await _userService.GetCreateDtoListAsync();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] UserAddDto userAddDto)
        {
            var result = await _userService.AddAsync(userAddDto);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UserUpdateDtos userUpdateDtos)
        {
            var result = await _userService.UpdateAsync(userUpdateDtos);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _userService.DeleteAsync(id);
            if (result)
            {
                return Ok(true);
            }
            return BadRequest(false);
        }
    }
}
