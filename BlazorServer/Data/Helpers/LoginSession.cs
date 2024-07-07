using BlazorServer.Data.Models;

namespace BlazorServer.Data.Helpers;

public class LoginSession
{
    public User? currentUser { get; set; }
    public bool IsUserLoggedIn { get; set; }
    public event Action? OnLoginStatusChanged;


    public bool Login(string username, string password, LoginManager loginManager)
    {
        var user = loginManager._users.FirstOrDefault(u => u.username.Equals(username) && u.password.Equals(password));
        if (user != null)
        {
            currentUser = user;
            IsUserLoggedIn = true;
            OnLoginStatusChanged?.Invoke();
            return true;
        }
        return false;
    }

    public void Logout()
    {
        IsUserLoggedIn = false;
        OnLoginStatusChanged?.Invoke();
        currentUser = null;
    }

    public void IvokeMenuUpdate()
    {
        OnLoginStatusChanged?.Invoke();
    }
}
