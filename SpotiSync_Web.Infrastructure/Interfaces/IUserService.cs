using SpotiSync_Web.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpotiSync_Web.Infrastructure.Interfaces
{
    public interface IUserService
    {
        SocketUser CreateNew(string name);
        SocketUser Get(string Id);
    }
}
