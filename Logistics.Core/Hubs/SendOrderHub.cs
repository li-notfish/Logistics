using Microsoft.AspNetCore.SignalR;

namespace Logistics.Core.Hubs
{
    public class SendOrderHub : Hub
    {
        public SendOrderHub()
        {
            
        }

		public async Task SendMessage(string user, string message,string groupName)
        {
            //await Clients.All.SendAsync("ReceiveMessage", user, message);
            await Clients.Group(groupName).SendAsync("ReceiveMessage",user,message);
        }

        public async Task AddToGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }
    }
}
