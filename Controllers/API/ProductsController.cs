using ASP.NET_Web.Models;
using ASP.NET_Web.Models.ProductEntity;
using ASP.NET_Web.Models.ProductEntity.dto;
using AutoMapper;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Web.Controllers.API;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(IMapper mapper): ControllerBase
{
    private readonly AspNetWebContext _context = new();
    private readonly IMapper _mapper = mapper;

    [HttpGet]
    public ActionResult<ProductDTO> GetProducts()
    {
        return Ok(_context.Product.ToList().Select(_mapper.Map<ProductDTO>));
    }

    [HttpGet("{id}")]
    public ActionResult<ProductDTO> GetProduct(int id)
    {
        var product = _context.Product.SingleOrDefault(p => p.Id == id);
        if(product == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<ProductDTO>(product));
    }

    [HttpPost]
    public ActionResult<EditProductDTO> CreateProduct(ProductDTO productDTO)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest();
        }

        var product = _mapper.Map<Product>(productDTO);
        _context.Product.Add(product);
        _context.SaveChanges();

        return Created(new Uri($"{Request.GetDisplayUrl()}/{product.Id}"), _mapper.Map<EditProductDTO>(product));
    }

    [HttpPut("{id}")]
    public ActionResult UpdateProduct(int id, ProductDTO productDTO)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest();
        }

        var productInDB = _context.Product.SingleOrDefault(p => p.Id == id);
        if(productInDB == null)
        {
            return NotFound();
        }

        _mapper.Map(productDTO, productInDB);
        _context.SaveChanges();

        return Ok();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteProduct(int id)
    {
        var productInDB = _context.Product.SingleOrDefault(p => p.Id == id);
        if(productInDB == null)
        {
            return NotFound();
        }

        _context.Product.Remove(productInDB);
        _context.SaveChanges();
        return NoContent();
    }
}