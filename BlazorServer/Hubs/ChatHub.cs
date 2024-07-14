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

    public async Task SendMessageToUser(Message message)
    {
        await Clients.Client(message.recipientUserId).SendAsync("ReceiveMessage", message);
        await Clients.Client(message.senderUserId).SendAsync("ReceiveMessage", message);
    }

    public string GetConnectionId()
    {
        return Context.ConnectionId;
    }
}

