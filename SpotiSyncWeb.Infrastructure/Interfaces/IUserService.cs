using SpotiSyncWeb.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpotiSyncWeb.Infrastructure.Interfaces
{
    public interface IUserService
    {
        SocketUser CreateNew(string name);
        SocketUser Get(string Id);
    }
}
