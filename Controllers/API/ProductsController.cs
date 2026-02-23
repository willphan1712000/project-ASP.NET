using ASP.NET_Web.Models;
using ASP.NET_Web.Models.ProductEntity;
using ASP.NET_Web.Models.ProductEntity.dto;
using ASP.NET_Web.Repo;
using AutoMapper;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Web.Controllers.API;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(IMapper mapper, IUnitOfWork unitOfWork): ControllerBase
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    [HttpGet]
    public ActionResult<ProductDTO> GetProducts()
    {
        return Ok(_unitOfWork.Product.GetAll().Select(_mapper.Map<ProductDTO>));
    }

    [HttpGet("{id}")]
    public ActionResult<ProductDTO> GetProduct(int id)
    {
        var product = _unitOfWork.Product.Get(id);
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
        _unitOfWork.Product.Add(product);
        _unitOfWork.Save();

        return Created(new Uri($"{Request.GetDisplayUrl()}/{product.Id}"), _mapper.Map<EditProductDTO>(product));
    }

    [HttpPut("{id}")]
    public ActionResult UpdateProduct(int id, ProductDTO productDTO)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest();
        }

        var productInDB = _unitOfWork.Product.Get(id);
        if(productInDB == null)
        {
            return NotFound();
        }

        _mapper.Map(productDTO, productInDB);
        _unitOfWork.Save();

        return Ok();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteProduct(int id)
    {
        var productInDB = _unitOfWork.Product.Get(id);
        if(productInDB == null)
        {
            return NotFound();
        }

        _unitOfWork.Product.Remove(productInDB);
        _unitOfWork.Save();
        
        return NoContent();
    }
}