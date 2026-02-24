namespace APS.NET_Web.Models.OrderEntity.dto;

public class CheckoutDTO
{
    public int Customer_id {get; set;}
    public DateTime ReturnDate {set; get;}
    required public List<int> Items {get;set;}
}