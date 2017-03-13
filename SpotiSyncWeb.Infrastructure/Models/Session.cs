using System;
using System.Collections.Generic;

namespace SpotiSyncWeb.Infrastructure.Models
{
    public class Session
    {
        public Session(SocketUser host)
        {
            this.Host = host;
            this.Listeners = new List<SocketUser>();
            this.Id = Guid.NewGuid().ToString().Split('-')[0].ToUpper();

            host.Session = this;
        }
        public string Id { get; set; }
        public SocketUser Host { get; set; }

        public IEnumerable<SocketUser> GetListeners()
        {
            return Listeners;
        }

        public void AddListener(SocketUser newListener)
        {
            newListener.Session = this;
            Listeners.Add(newListener);

            // Todo Notify this listener about what song to play
        }

        public void SetTrack(TrackEvent track)
        {

        }

        public void RemoveListener(SocketUser removeMe)
        {
            removeMe.Session = null;
            Listeners.Remove(removeMe);
        }

        private IList<SocketUser> Listeners {get; set;}
    }
}
