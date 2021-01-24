using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using Project4._0_BackEnd.Models;

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

        public async Task SendMessageAsync(Message message)
        {
            
                await Clients.All.SendAsync("RecieveMessage", message);
          
            
        }
    }
}
