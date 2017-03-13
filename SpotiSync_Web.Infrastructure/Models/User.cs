using Newtonsoft.Json;
using SpotiSync_Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SpotiSync_Web.Infrastructure.Models
{
    public class SocketUser: User, IDisposable
    {
        public Session Session { get; set; }
        private CancellationTokenSource source { get; set; }

        public SocketUser(string name)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
        }

        public async void NotifyTrackChange(TrackEvent track)
        {
           
        }        

        public async void Connect()
        {
            
        }

        public void Dispose()
        {
            

            throw new NotImplementedException();
        }
    }
}
