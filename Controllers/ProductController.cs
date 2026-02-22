using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ASP.NET_Web.Models;
using ASP.NET_Web.Models.ProductEntity;
using ASP.NET_Web.Models.ProductEntity.dto;
using AutoMapper;

namespace ASP.NET_Web.Controllers;

public class ProductController(IMapper mapper) : Controller
{
    private readonly AspNetWebContext _context = new();
    private readonly IMapper _mapper = mapper;

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

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult SaveNew(ProductDTO productDTO)
    {
        if(!ModelState.IsValid)
        {
            return View("New", productDTO);
        }
        
        _context.Add(_mapper.Map<Product>(productDTO));
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

        return View(_mapper.Map<EditProductDTO>(product));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult SaveEdit(EditProductDTO editProductDTO)
    {
        if(!ModelState.IsValid)
        {
            return View("Edit", editProductDTO);    
        }

        var productInDB = _context.Product.Single(p => p.Id == editProductDTO.Id);
        productInDB.Name = editProductDTO.Name;
        productInDB.Price = editProductDTO.Price;
        productInDB.Stock = editProductDTO.Stock;

        _context.SaveChanges();

        return RedirectToAction("Index", "Product");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
