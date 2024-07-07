using BlazorServer.Data.Models;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;

namespace BlazorServer.Hubs;
public class ChatHub : Hub
{
    public Task SendMessage(string user, string message)
    {
        return Clients.All.SendAsync("ReceiveMessage", user, message);
    }

    public async Task SendMessageToUser(string recipientUserId, string senderUserName, string message)
    {
        await Clients.Client(recipientUserId).SendAsync("ReceiveMessage", senderUserName, message);
    }

    public string GetConnectionId()
    {
        return Context.ConnectionId;
    }
}

