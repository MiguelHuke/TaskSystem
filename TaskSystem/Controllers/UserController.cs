﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskSystem.Model;
using TaskSystem.Repository.Interfaces;

namespace TaskSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository) {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> GetAllUsers()
        {
            List<UserModel> users = await _userRepository.GetAllUsers();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<UserModel>>> GetUserById(int id)
        {
            UserModel user = await _userRepository.GetUserById(id);
            return Ok(user);
        }
        [HttpPost]
        public async Task<ActionResult<UserModel>> Register([FromBody] UserModel userModel)
        {
            UserModel user = await _userRepository.AddUser(userModel);
            return Ok(user);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<UserModel>> Register([FromBody] UserModel userModel, int id)
        {
            userModel.Id = id;
            UserModel user = await _userRepository.UpdateUser(userModel, id);
            return Ok(user);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserModel>> Delete(int id) { 
        bool deleted = await _userRepository.DeleteUser(id);
        return Ok(deleted); 
    }
    }
}
