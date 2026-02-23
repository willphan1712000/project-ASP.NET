using ASP.NET_Web.Models;
using ASP.NET_Web.Models.CustomerEntity.Repo;

namespace ASP.NET_Web.Repo;

public class UnitOfWork : IUnitOfWork
{
    private readonly AspNetWebContext _context;
    public ICustomerRepo Customer {get; private set;}

    public UnitOfWork(AspNetWebContext context)
    {
        _context = context;
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