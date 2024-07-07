using BlazorServer.Data.Models;

namespace BlazorServer.Data.Helpers;

public class LoginManager
{
public List<User> _users = new List<User> { new User("a","a"), new User("b", "b") };
//public User? currentUser { get; set; }

    public LoginManager()
    {
       // _users = new List<User> { new User("a","a"), new User("b", "b") };
    }

    //public bool Login(string username, string password)
    //{
    //    var user = _users.FirstOrDefault(u => u.username.Equals(username) && u.password.Equals(password));
    //    if (user != null)
    //    {
    //        currentUser = user;
    //        return true;
    //    }
    //    return false;
    //}

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

    public string? GetConnectionId(string userName)
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

    //public void Logout()
    //{
    //    currentUser = null;
    //}
    
    public void Register(string username, string password)
    {
        _users.Add(new User(username, password));
    }

}
