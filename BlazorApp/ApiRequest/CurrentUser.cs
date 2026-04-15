using BlazorApp.ApiRequest.Model;

namespace BlazorApp.ApiRequest;

public class CurrentUser
{
    public string CurrentRole;
    public bool IsLoggedIn = false;
    
    public void Login(string role)
    {
        CurrentRole = role;
        IsLoggedIn = true;
        Console.WriteLine(CurrentRole);
        Console.WriteLine(IsLoggedIn);
    }
    
    public void Logout()
    {
        CurrentRole = "";
        IsLoggedIn = false;
    }
}