using BlazorServer.Data.Models;

namespace BlazorServer.Data.Helpers;

public class LoginManager
{
    public List<User> _users { get; set; }

    public LoginManager()
    {
        _users= new List<User> { new User("a", "a"), new User("b", "b"), new User("c", "c"), new User("d", "d") };
    }

    public bool MapUserToConnection(string connectionId,string? userName)
    {
        var user= _users.FirstOrDefault(u => u.username.Equals(userName));
        if (user is null)
        {
            return false; 
        }
        else
        {
            user.connectionId = connectionId;
            return true;
        }
    }

    public string? GetConnectionId(string? userName)
    {
        var user = _users.FirstOrDefault(u => u.username.Equals(userName));
        if (user is null)
        {
            return null;
        }
        else
        {
            return user.connectionId;
        }
    }
    
    public void Register(string username, string password)
    {
        _users.Add(new User(username, password));
    }

    public List<User> GetAllUsers()
    {

       return _users.OrderBy(x=>x.username).ToList();
    }

}
