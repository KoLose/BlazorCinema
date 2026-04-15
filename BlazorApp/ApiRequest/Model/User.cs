using System.Globalization;

namespace BlazorApp.ApiRequest.Model;

public class UserDataShort
{
    public string UserName { get; set; }
    public string Mail { get; set; }
    public string Password { get; set; }
    public string Role { get; set; } 
    public string Action { get; set; }
}


public class UserData
{
    public UserDataContainer data  { get; set; }
    public bool status { get; set; }
}

public class UserAddData
{
    public bool status { get; set; }
    public string role {get; set;}
}

public class UserDataContainer
{
    public List<UserDataShort> users { get; set; }
}
