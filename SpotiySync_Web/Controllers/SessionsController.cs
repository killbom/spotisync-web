using Microsoft.AspNetCore.Mvc;
using SpotiSync_Web.Infrastructure.Interfaces;
using SpotiySync_Web.Dtos;

namespace SpotiySync_Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class SessionsController : Controller
    {
        private ISessionService sessions;
        private IUserService users;

        public SessionsController(ISessionService sessions, IUserService users)
        {
            this.sessions = sessions;
            this.users = users;
        }

        // GET api/session/new
        [HttpGet("new/{userId}")]
        public SessionDto CreateSession(string userId)
        {
            var user = users.Get(userId);
            return new SessionDto(sessions.StartNew(user));
        }

        // GET api/values/5
        [HttpGet("join/{sessionId}/{userId}")]
        public IActionResult Get(string sessionId, string userId)
        {
            var user = users.Get(userId);
            sessions.JoinSession(sessionId, user);

            return Ok();
        }
    }
}