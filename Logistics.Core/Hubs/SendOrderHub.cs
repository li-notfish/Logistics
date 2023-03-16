using Microsoft.AspNetCore.SignalR;

namespace Logistics.Core.Hubs
{
    public class SendOrderHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
