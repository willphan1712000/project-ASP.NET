using APS.NET_Web.Repo;
using ASP.NET_Web.Repo;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Web.Models.ProductEntity.Repo;

public class ProductRepo(DbContext context) : Repo<Product>(context), IProductRepo
{
}