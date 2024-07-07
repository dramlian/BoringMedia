using BlazorServer.Data.Models;

namespace BlazorServer.Data.Helpers;

public class LoginSession
{
    public User? currentUser { get; set; }

    private LoginManager loginManager { get;set; }

    public LoginSession(LoginManager loginManager)
    {
        this.loginManager = loginManager;
    }

    public bool Login(string username, string password)
    {
        var user = loginManager._users.FirstOrDefault(u => u.username.Equals(username) && u.password.Equals(password));
        if (user != null)
        {
            currentUser = user;
            return true;
        }
        return false;
    }

    public void Logout()
    {
        currentUser = null;
    }
}
