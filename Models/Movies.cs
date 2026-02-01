using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Web.Models;

public class Movie(string name)
{
    public int Id {get; set;}
    public string Name { get; set; } = name;
}

public class Movies()
{
    public List<Movie> GetMovieList()
    {
        return [
            new Movie("Silicon Valley"),
            new Movie("The Hunger Game")
        ];
    }
}