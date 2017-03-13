using System;
using System.Collections.Generic;

namespace SpotiSync_Web.Domain.Models
{
    public class Session
    {
        public Session(User host)
        {
            this.Host = host;
            this.Listeners = new List<User>();
            this.Id = Guid.NewGuid().ToString().Split('-')[0].ToUpper();

            host.Session = this;
        }
        public string Id { get; set; }
        public User Host { get; set; }

        public IEnumerable<User> GetListeners()
        {
            return Listeners;
        }

        public void AddListener(User newListener)
        {
            newListener.Session = this;
            Listeners.Add(newListener);

            // Todo Notify this listener about what song to play
        }

        public void RemoveListener(User removeMe)
        {
            removeMe.Session = null;
            Listeners.Remove(removeMe);
        }

        private IList<User> Listeners {get; set;}
    }
}
