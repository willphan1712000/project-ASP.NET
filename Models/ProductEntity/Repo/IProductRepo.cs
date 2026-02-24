using ASP.NET_Web.Repo;

namespace ASP.NET_Web.Models.ProductEntity.Repo;

public interface IProductRepo : IRepo<Product>
{
    public List<Product> GetProductsFromRange(List<int> range);
}