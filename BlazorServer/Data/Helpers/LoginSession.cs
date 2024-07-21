using BlazorServer.Data.Database;
using BlazorServer.Data.Models;

namespace BlazorServer.Data.Helpers;

public class LoginSession
{
    public User? currentUser { get; set; }
    public bool IsUserLoggedIn { get; set; }
    public event Action? OnLoginStatusChanged;
    private readonly UsersContext _context; 

    public LoginSession(UsersContext context)
    {
        _context = context;
    }

    public bool Login(string username, string password, UserConnectionMapper loginManager)
    {
        var user = _context.BoringMediaUsers.FirstOrDefault(u => u.username.Equals(username) && u.password.Equals(password));
        if (user != null)
        {
            currentUser = user;
            IsUserLoggedIn = true;
            IvokeMenuUpdate();
            return true;
        }
        return false;
    }

    public void Logout()
    {
        IsUserLoggedIn = false;
        IvokeMenuUpdate();
        currentUser = null;
    }

    public void IvokeMenuUpdate()
    {
        OnLoginStatusChanged?.Invoke();
    }


    public void Register(string username, string password)
    {
        _context.BoringMediaUsers.Add(new User(username, password));
        _context.SaveChanges();
    }

    public List<User> GetAllUsers()
    {
        return _context.BoringMediaUsers.OrderBy(x => x.username).ToList();
    }

    public bool DoesUserExist(string username)
    {
        return _context.BoringMediaUsers.Any(u => u.username.Equals(username));
    }
}
