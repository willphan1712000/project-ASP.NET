using ASP.NET_Web.Models.OrderEntity;
using ASP.NET_Web.Models.ProductEntity;
using ASP.NET_Web.Models.ProfileEntity;

namespace ASP.NET_Web.Models.CustomerEntity;

public class Customer(string name, string email, string password)
{
    public int Id {get; set;}
    public string Name { get; set;} = name;
    public string Password { get; set;} = password;
    public string Email { get; set;} = email;
    public List<Order> Orders {get; set;} = [];
    public List<Product> Products {get; set;} = [];
    public Profile? Profile {get; set;}
}

public class Customers
{
    public List<Customer> GetCustomers()
    {
        return [
            new Customer("Will", "will@gmail.com", "123"),
            new Customer("Trang", "trang@gmail.com", "123"),
            new Customer("Huu", "huu@gmail.com", "123"),
            new Customer("Ngan", "ngan@gmail.com", "123"),
        ];
    }
}