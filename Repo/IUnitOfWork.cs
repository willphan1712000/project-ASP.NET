using ASP.NET_Web.Models.CustomerEntity.Repo;

namespace ASP.NET_Web.Repo;

public interface IUnitOfWork : IDisposable
{
    ICustomerRepo Customer {get;}

    int Save();
}