using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Web.Controllers;

public class ErrorController : Controller
{
    [Route("Error/{statusCode}")]
    public IActionResult CustomerError(int statusCode)
    {
        ViewBag.ErrorMessage = statusCode switch
        {
            404 => "404 - Not Found",
            403 => "403 - Forbidden",
            _ => "Sorry, unexpected error occurred.",
        };

        return View("Error");
    }

    [Route("Error/500")]
    public IActionResult Error()
    {
        ViewBag.ErrorMessage = "500";
        return View();
    }
}