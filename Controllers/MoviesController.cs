using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ASP.NET_Web.Models;

namespace ASP.NET_Web.Controllers;

public class MoviesController : Controller
{
    public IActionResult Index()
    {
        var movies = new Movies();
        return View(movies);
    }

    [Route("movies/releaseDate/{year}/{month:regex(\\d{{1}}|d{{2}}):range(1,12)}")]
    public IActionResult Release(int? year, int? month)
    {
        return Content("year " + year + " month " + month);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
