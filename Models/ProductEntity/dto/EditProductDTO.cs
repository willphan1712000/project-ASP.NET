namespace ASP.NET_Web.Models.ProductEntity.dto;

public class EditProductDTO : ProductDTO
{
    public int Id {get; set;}

    public static EditProductDTO ToDTO(Product product)
    {
        return new EditProductDTO
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Stock = product.Stock
        };
    }
}