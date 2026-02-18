namespace ASP.NET_Web.Models;

public class Test(string name)
{
    public int Id {get; set;}
    public string Name { get; set; } = name;
}