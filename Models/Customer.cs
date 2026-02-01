using System.ComponentModel.DataAnnotations;

namespace ASP.NET_Web.Models;

public class Customer(string name)
{
    public int Id {get; set;}
    [Required]
    [StringLength(255)]
    public string Name { get; set;} = name;
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