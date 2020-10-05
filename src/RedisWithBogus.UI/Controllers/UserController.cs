using Microsoft.AspNetCore.Mvc;
using RedisWithBogus.Application.Interfaces;
using RedisWithBogus.Domain.Entities;
using System.Collections.Generic;

namespace RedisWithBogus.UI.Controllers
{
    [Produces("application/json")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("getusers")]
        public IEnumerable<User> GetUsers()
            => _service.GetUsers();
    }
}