using APS.NET_Web.Repo;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Web.Models.CustomerEntity.Repo;

public class CustomerRepo(DbContext context) : Repo<Customer>(context), ICustomerRepo
{
    
}