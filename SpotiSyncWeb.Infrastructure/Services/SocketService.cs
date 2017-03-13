using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;

namespace SpotiSyncWeb.Infrastructure.Services
{
    public static class SocketService
    {
        private static ConcurrentDictionary<string, WebSocket> _sockets = new ConcurrentDictionary<string, WebSocket>();

        public static EventHandler<string> OnUserConnected { get; set; }

        public static void UseSocketService(this IApplicationBuilder app)
        {
            app.UseWebSockets();
            app.Use(async (http, next) =>
            {
                if (http.WebSockets.IsWebSocketRequest)
                {
                    var webSocket = await http.WebSockets.AcceptWebSocketAsync();
                    if (webSocket != null && webSocket.State == WebSocketState.Open)
                    {
                        try
                        {
                            var userId = http.Request.Query.First(q => q.Key == "userId").Value;
                            _sockets.TryAdd(userId, webSocket);
                            OnUserConnected(webSocket, userId);

                        } catch (Exception)
                        {
                            await webSocket.CloseAsync(WebSocketCloseStatus.EndpointUnavailable, "User not recognized", new System.Threading.CancellationToken());
                        }
                    }
                }
                else
                {
                    await next();
                }
            });
        }
    }
}
