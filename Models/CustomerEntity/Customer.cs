using ASP.NET_Web.Models.OrderEntity;
using ASP.NET_Web.Models.ProductEntity;
using ASP.NET_Web.Models.ProfileEntity;

namespace ASP.NET_Web.Models.CustomerEntity;

public class Customer(string name)
{
    public int Id {get; set;}
    public string Name { get; set;} = name;
    public List<Order> Orders {get; set;} = [];
    public List<Product> Products {get; set;} = [];
    public Profile? Profile {get; set;}
}

public class Customers
{
    public List<Customer> GetCustomers()
    {
        return [
            new Customer("Will"),
            new Customer("Trang"),
            new Customer("Huu"),
            new Customer("Ngan"),
        ];
    }
}