using Newtonsoft.Json;
using SpotiSync_Common;
using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpotiSyncWeb.Infrastructure.Models
{
    public class SocketUser: User, IDisposable
    {
        public Session Session { get; set; }
        private WebSocket socket { get; set; }

        public SocketUser(string name)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
        }

        public async Task NotifyTrackChange(TrackEvent track)
        {
            if (socket != null && socket.State == WebSocketState.Open)
            {
                try
                {
                    string json = JsonConvert.SerializeObject(track);
                    var buff = new ArraySegment<byte>(Encoding.UTF8.GetBytes(json));
                    await socket.SendAsync(buff, WebSocketMessageType.Binary, true, CancellationToken.None);
                } 
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

            }   
        }        

        public async Task Connect(WebSocket socket)
        {
            this.socket = socket;

            if (Session.CurrentTrack != null)
            {
                await NotifyTrackChange(Session.CurrentTrack);
            }
        }

        public void Dispose()
        { 
            throw new NotImplementedException();
        }
    }
}
