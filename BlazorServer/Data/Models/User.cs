namespace BlazorServer.Data.Models;

public class User
{
    public int Id { get; set; }
    public string username { get; init; }
    public string password { get; init; }
    public string? connectionId { get; set; }    
    public List<string> friends { get; set; }


    public User(string username,string password)
    {
        this.username = username;
        this.password = password;
        this.friends = new List<string>();
    }
}
