using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Web.Models.CustomerEntity;

public class CustomerRepo
{
    private readonly AspNetWebContext context;
    public CustomerRepo() {
        context = new AspNetWebContext();
    }

    public void GetCustomersLINQ()
    {
        // Get
        var customersLINQ = 
            from c in context.Customer
            where c.Name == "Trang"
            orderby c.Name
            select new { c.Email };

        foreach (var customer in customersLINQ )
        {
            System.Console.WriteLine(customer.Email);
        }

        // Group
        var groups =
            from c in context.Customer
            group c by c.Name
            into g
            select new { Name = g.Key, Count = g.Count() };

        foreach(var group in groups)
        {
            System.Console.WriteLine("{0} ({1})", group.Name, group.Count);
        }

        // Join
        var joins =
            from c in context.Customer
            select new { Name = c.Name, Profile = c.Profile ?? null };

        foreach(var join in joins)
        {
            System.Console.WriteLine("Name {0}, Facebook {1}", join.Name, join.Profile == null ? "No Facebook" : join.Profile.Facebook );
        }
    }

    public void GetCustomersExtension()
    {
        // Getting
        var customersExtension = context.Customer
            .Where(c => c.Name == "Trang")
            .OrderBy(c => c.Name);

        foreach (var customer in customersExtension )
        {
            System.Console.WriteLine(customer.Email);
        }

        // Group
        var groups = context.Customer
            .GroupBy(c => c.Name);

        foreach(var group in groups)
        {
            System.Console.WriteLine(group.Key);
            foreach(var c in group)
            {
                System.Console.WriteLine("\t" + c.Email);
            }
        }

        // Join
        var joins = context.Customer.Join(
            context.Profile,
            c => c.Id,
            p => p.Customer_id,
            (customer, profile) => new
            {
                Name = customer.Name,
                Facebook = profile.Facebook
            }
        );

        foreach(var join in joins)
        {
            System.Console.WriteLine("Name: {0}, Facebook: {1}", join.Name, join.Facebook);
        }

        // Partition
        var customers = context.Customer.Skip(1).Take(2);
        foreach(var customer in customers)
        {
            System.Console.WriteLine(customer.Name);
        }

        // Quantifying
        var all = context.Customer.All(c => c.Email == "nha@gmail.com");
        var any = context.Customer.Any(c => c.Email == "will@gmail.com");
        System.Console.WriteLine(all);
        System.Console.WriteLine(any);
    }

    public void EagerLoading()
    {
        // Eager Loading
        var customers = context.Customer.Include(c => c.Orders).ToList();
        foreach(var customer in customers)
        {
            System.Console.WriteLine("Customer: " + customer.Name);
            foreach(var order in customer.Orders)
            {
                System.Console.WriteLine("\t" + order.Status);
            }
        }

        // Explicit Loading
        var users = context.Customer.ToList();
        var userIds = users.Select(u => u.Id);
        var orders = context.Order.Where(o => userIds.Contains(o.Customer_id) && o.Price > 35);
        foreach(var order in orders)
        {
            System.Console.WriteLine(order.Id);
        }
    }
}