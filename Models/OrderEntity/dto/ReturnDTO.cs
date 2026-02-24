namespace ASP.NET_Web.Models.OrderEntity.Repo;

public class ReturnDTO
{
    public int OrderId {get; set;}
    required public List<int> Items {get; set;}
}