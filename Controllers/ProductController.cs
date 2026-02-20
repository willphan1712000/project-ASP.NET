using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ASP.NET_Web.Models;
using ASP.NET_Web.Models.ProductEntity;

namespace ASP.NET_Web.Controllers;

public class ProductController : Controller
{
    private AspNetWebContext _context;
    public ProductController()
    {
        _context = new AspNetWebContext();
    }
    protected override void Dispose(bool disposing)
    {
        _context.Dispose();
        base.Dispose(disposing);
    }
    public IActionResult Index()
    {
        var products = _context.Product.ToList();
        return View(products);
    }
    public IActionResult New()
    {
        return View(null);
    }

    public IActionResult Save(Product product)
    {
        if(product.Id == 0)
        {
            _context.Add(product);    
        } else
        {
            var productInDb = _context.Product.Single(p => p.Id == product.Id);
            productInDb.Name = product.Name;
            productInDb.Price = product.Price;
            productInDb.Stock = product.Stock;
        }
        _context.SaveChanges();
        return RedirectToAction("Index", "Product");
    }

    public IActionResult Edit(int id)
    {
        var product = _context.Product.SingleOrDefault(p => p.Id == id);
        if(product == null)
        {
            return NotFound();
        }

        return View("New", product);
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
