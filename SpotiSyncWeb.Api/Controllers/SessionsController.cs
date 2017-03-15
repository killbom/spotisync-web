using Microsoft.AspNetCore.Mvc;
using SpotiSyncWeb.Dtos;
using SpotiSync_Common;
using SpotiSyncWeb.Infrastructure.Interfaces;
using SpotiSyncWeb.Infrastructure.Models;
using System.Threading.Tasks;

namespace SpotiSyncWeb.Controllers
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

        [HttpPost("play/{sessionId}/{userId}")]
        public async Task<IActionResult> SetTrack(string sessionId, string userId, [FromBody]TrackEvent track)
        {
            var session = sessions.GetSession(sessionId);
            var user = users.Get(userId);

            if(session.Host.Id != user.Id)
            {
                return BadRequest("You do not own this session");
            }

            await session.SetTrack(track);

            return Ok();
        }
    }
}