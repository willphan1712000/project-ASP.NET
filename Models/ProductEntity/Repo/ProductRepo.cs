using APS.NET_Web.Repo;

namespace ASP.NET_Web.Models.ProductEntity.Repo;

public class ProductRepo(AspNetWebContext context) : Repo<Product>(context), IProductRepo
{
    public readonly AspNetWebContext _context = context;

    // Get products from a list of id
    public List<Product> GetProductsFromRange(List<int> range)
    {
        return [.. _context.Product.Where(p => range.Contains(p.Id))];
    }
}