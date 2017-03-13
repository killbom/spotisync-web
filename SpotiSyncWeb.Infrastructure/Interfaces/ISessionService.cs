using SpotiSyncWeb.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpotiSyncWeb.Infrastructure.Interfaces
{
    public interface ISessionService
    {
        Session StartNew(SocketUser host);
        void JoinSession(string sessionId, SocketUser listener);
        Session GetSession(string sessionId);
    }
}
