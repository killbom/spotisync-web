using SpotiSyncWeb.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpotiSyncWeb.Dtos
{
    public class SessionDto
    {
        public SessionDto(Session session)
        {
            this.Id = session.Id;
        }
        public string Id { get; set; }
    }
}
