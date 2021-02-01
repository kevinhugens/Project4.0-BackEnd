using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using Project4._0_BackEnd.Models;
using System.Collections;

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

        public async Task JoinRoom(string roomName)
        {   
            await Groups.AddToGroupAsync(Context.ConnectionId, roomName);
            //hier kan eventueel een bericht verstuurd worden dat de gebruiker in de room is.
        }

        public async Task SendMessageToRoomAsync(Message message, string roomName)
        {
            await Clients.Group(roomName).SendAsync("RecieveMessage", message);
        }

        public async Task SendPollAsync(Poll poll, string roomName)
        {
            Console.WriteLine("connected to " + roomName);
            await Clients.Group(roomName).SendAsync("ReceivePoll", poll);
        }

        public async Task SendQuestionAsync(Message message, string roomName)
        {
            await Clients.Group(roomName).SendAsync("ReceiveQuestion", message);
        }
    }
}
