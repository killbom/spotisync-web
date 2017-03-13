using System;
using System.Collections.Generic;
using System.Text;

namespace SpotiSync_Web.Domain.Models
{
    public class User
    {
        public User(string name)
        {
            this.Id = Guid.NewGuid().ToString();
            this.Name = name;
        }
        public string Id { get; private set; }
        public string Name { get; private set; }
        public Session Session { get; set; }
    }
}
