using SpotiSync_Web.Infrastructure.Models;
using SpotiSync_Web.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpotiSync_Web.Infrastructure.Services
{
    public class UserService: IUserService
    {
        private static Dictionary<string, SocketUser> users = new Dictionary<string, SocketUser>();

        public SocketUser CreateNew(string name)
        {
            var newUser = new SocketUser(name);
            users.Add(newUser.Id, newUser);

            return newUser;
        }

        public SocketUser Get(string id)
        {
            return users[id];
        }
    }
}
