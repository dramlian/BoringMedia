using BlazorServer.Data.Database;
using BlazorServer.Data.Models;

namespace BlazorServer.Data.Helpers;

public class UserConnectionMapper
{
    public List<User> mappedActiveUsers { get; set; }

    public UserConnectionMapper()
    {
        mappedActiveUsers = new List<User>();
    }

    public bool MapUserToConnection(string connectionId,User? nonRegisterdUser)
    {
        if (nonRegisterdUser is null)
        {
            return false; 
        }
        else
        {
            nonRegisterdUser.connectionId = connectionId;
            mappedActiveUsers.Add(nonRegisterdUser);
            return true;
        }
    }

    public string? GetConnectionId(string? userName)
    {
        var user = mappedActiveUsers.FirstOrDefault(u => u.username.Equals(userName));
        if (user is null){return null;}

        return user.connectionId; 
    }
    
}
