using SpotiSync_Web.Infrastructure.Interfaces;
using SpotiSync_Web.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpotiSync_Web.Infrastructure.Services
{
    public class SessionService : ISessionService
    {
        private static Dictionary<string, Session> sessions = new Dictionary<string, Session>();

        private IUserService users;

        public SessionService(IUserService users)
        {
            this.users = users;
            SocketService.OnUserConnected += UserConnected;
        }

        public Session StartNew(SocketUser host)
        {
            if (sessions.ContainsKey(host.Session.Id))
            {
                foreach (var listener in sessions[host.Session.Id].GetListeners())
                {
                    listener.Dispose();
                }
            }

            var newSession = new Session(host);
            sessions.Add(newSession.Id, newSession);

            return newSession;
        }

        public void JoinSession(string sessionId, SocketUser listener)
        {
            var session = sessions[sessionId];
            session.AddListener(listener);
        }

        private void UserConnected(object sender, string userId)
        {
            var user = users.Get(userId);

            // Manage the websocket
            new Task(() =>
            {
                user.Connect();
            }).Start();
        }
    }
}
