using ASP.NET_Web.Models.CustomerEntity.Repo;
using ASP.NET_Web.Models.ProductEntity.Repo;

namespace ASP.NET_Web.Repo;

public interface IUnitOfWork : IDisposable
{
    ICustomerRepo Customer {get;}
    IProductRepo Product {get;}

    int Save();
}