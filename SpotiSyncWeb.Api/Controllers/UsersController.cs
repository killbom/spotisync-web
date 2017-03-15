using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpotiSyncWeb.Dtos;
using SpotiSync_Common;
using SpotiSyncWeb.Infrastructure.Interfaces;

namespace SpotiSyncWeb.Controllers
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
        public User New([FromBody]User user)
        {
            return users.CreateNew(user.Name);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public User Get(string id)
        {
            return users.Get(id);
        }
    }
}