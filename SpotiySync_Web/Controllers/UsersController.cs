using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpotiSync_Web.Infrastructure.Interfaces;
using SpotiySync_Web.Dtos;
using SpotiSync_Web.Infrastructure.Models;
using SpotiSync_Common;

namespace SpotiySync_Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private IUserService users;

        public UsersController(IUserService users)
        {
            this.users = users;
        }

        // GET api/session/new
        [HttpPost("new")]
        public User CreateSession([FromBody]string name)
        {
            return users.CreateNew(name);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public User Get(string id)
        {
            return users.Get(id);
        }
    }
}