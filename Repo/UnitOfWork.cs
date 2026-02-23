using ASP.NET_Web.Models;
using ASP.NET_Web.Models.CustomerEntity.Repo;
using ASP.NET_Web.Models.ProductEntity;
using ASP.NET_Web.Models.ProductEntity.Repo;

namespace ASP.NET_Web.Repo;

public class UnitOfWork : IUnitOfWork
{
    private readonly AspNetWebContext _context = new();
    public ICustomerRepo Customer {get; private set;}

    public IProductRepo Product {get; private set;}

    public UnitOfWork()
    {
        Customer = new CustomerRepo(_context);
        Product = new ProductRepo(_context);
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public int Save()
    {
        return _context.SaveChanges();
    }
}