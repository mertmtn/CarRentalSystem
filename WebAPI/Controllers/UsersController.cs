﻿using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _userService.GetAll();
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _userService.GetById(id);
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpPost("Add")]
        public IActionResult Add(User user)
        {
            //TODO: İş kurallarında kullanıcı şifresi hashlenecek
            //TODO: Kullanıcı şifresi bir büyük harf bür küçük harf sayı içerecek ve en az 8 karakter olacak

            var result = _userService.Add(user);
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpPost("UpdatePassword")]
        public IActionResult UpdatePassword(User user)
        {
            var result = _userService.UpdatePassword(user);
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpPost("UpdateUserInfo")]
        public IActionResult UpdateUserInfo(User user)
        {
            var result = _userService.UpdateUserInfo(user);
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(User user)
        {
            var result = _userService.Delete(user);
            return StatusCode(result.Success ? 200 : 400, result);
        }



    }
}
