using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Common.WebApi.DataTransferObjects;
using Common.WebApi.Models;
using Common.WebApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace Common.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {

            _userService = userService;
            _mapper = mapper;

        }

        // GET: api/User
        [HttpGet]
        public IActionResult Get()
        {

            var userModels = _userService.GetAll().ToList();

            var users = _mapper.Map<List<User>>(userModels);

            return Ok(users);
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var userModel = _userService.GetById(id);

            var user = _mapper.Map<User>(userModel);

            return Ok(user);
        }

        // POST: api/User
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            var userModel = _mapper.Map<UserModel>(user);
            var newUserModel = _userService.Create(userModel);

            return Ok(newUserModel);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User user)
        {
            var userModel = _mapper.Map<UserModel>(user);
            userModel.Id = id;
            var updatedUserModel = _userService.Update(userModel);

            return Ok(updatedUserModel);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
           _ = _userService.Delete(id);
        }

        [AllowAnonymous]
        [HttpPost("Authenticate")]
        [SwaggerResponse(typeof(AuthenticatedUser))]
        [SwaggerResponse(typeof(UnauthorizedObjectResult))]
        public IActionResult Authenticate([FromBody] Authenticate model)
        {
            var user = _userService.Authenticate(model.Username, model.Password);

            if (user == null)
                return Unauthorized("Username or Password is incorrect");

            var authenticatedUser = new AuthenticatedUser()
            {
                UserId = user.Id,
                Token = user.Token

            };

            return Ok(authenticatedUser);
        }
    }
}
