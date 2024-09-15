using System.Net;

using API.Services;

using Microsoft.AspNetCore.Mvc;

using System.Net.WebSockets;
using System.Text;
using System.Text.Json;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class Websocket : ControllerBase
    {
        public async Task ObterDados([FromServices] WebsocketObterDados websocketObterDados)
        {
            if (!HttpContext.WebSockets.IsWebSocketRequest)
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return;
            }

            using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
            while (true)
            {
                var json = JsonSerializer.Serialize(websocketObterDados.Payload);
                await webSocket.SendAsync(
                    Encoding.ASCII.GetBytes(json),
                    WebSocketMessageType.Text,
                    true, CancellationToken.None);
                await Task.Delay(1000);
            }
        }
    }
}