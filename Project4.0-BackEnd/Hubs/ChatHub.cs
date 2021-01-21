using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;

namespace Project4._0_BackEnd.Hubs
{
    public class ChatHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            Console.WriteLine("Connected" + Context.ConnectionId);
            Clients.Clients(Context.ConnectionId).SendAsync("RecievedCon", Context.ConnectionId);
            return base.OnConnectedAsync();
        }

        public async Task SendMessageAsync(string message)
        {
            var routeOB = JsonConvert.DeserializeObject<dynamic>(message);
            string toClient = routeOB.To;
            Console.WriteLine("message recieved on" + Context.ConnectionId);

            if (toClient == string.Empty)
            {
                await Clients.All.SendAsync("RecieveMessage", message);
            }
            else
            {
                await Clients.Clients(toClient).SendAsync("RecieveMessage", message);
            }
        }
    }
}
