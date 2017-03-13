using SpotiSync_Web.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpotiSync_Web.Infrastructure.Interfaces
{
    public interface ISessionService
    {
        Session StartNew(SocketUser host);
        void JoinSession(string sessionId, SocketUser listener);
    }
}
