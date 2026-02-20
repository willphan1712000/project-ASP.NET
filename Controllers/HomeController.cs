using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ASP.NET_Web.Models;

namespace ASP.NET_Web.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Math(int? id, string sortBy)
    {
        if(!id.HasValue)
        {
            id = 0;
        }

        if(String.IsNullOrWhiteSpace(sortBy))
        {
            sortBy = "name";
        }

        return Content(String.Format("id={0} and sortBy={1}", id, sortBy));
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
