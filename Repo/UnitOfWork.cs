using ASP.NET_Web.Models;
using ASP.NET_Web.Models.CustomerEntity.Repo;

namespace ASP.NET_Web.Repo;

public class UnitOfWork : IUnitOfWork
{
    private readonly AspNetWebContext _context = new();
    public ICustomerRepo Customer {get; private set;}

    public UnitOfWork()
    {
        Customer = new CustomerRepo(_context);
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