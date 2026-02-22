using AutoMapper;

namespace ASP.NET_Web.Models.ProductEntity.dto;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductDTO>();
        CreateMap<ProductDTO, Product>();
        CreateMap<Product, EditProductDTO>();
    }
}