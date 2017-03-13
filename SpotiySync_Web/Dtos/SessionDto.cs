using SpotiSync_Web.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpotiySync_Web.Dtos
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
