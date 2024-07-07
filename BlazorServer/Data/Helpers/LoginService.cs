namespace BlazorServer.Data.Helpers;

public class LoginService
{
    public bool IsUserLoggedIn { get; private set; }
    public event Action? OnLoginStatusChanged;

    public void Login()
    {
        IsUserLoggedIn = true;
        OnLoginStatusChanged?.Invoke();
    }

    public void Logout()
    {
        IsUserLoggedIn = false;
        OnLoginStatusChanged?.Invoke();
    }
}
