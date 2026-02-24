using APS.NET_Web.Models.OrderEntity.dto;
using ASP.NET_Web.DTO;
using ASP.NET_Web.Models.MembershipTypeEntity;
using ASP.NET_Web.Models.OrderEntity;
using ASP.NET_Web.Models.OrderItemEntity;
using ASP.NET_Web.Repo;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Web.Controllers.API;

[ApiController]
[Route("api/checkout")]
public class CheckoutController(IUnitOfWork unitOfWork) : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    [HttpPost]
    public ActionResult<CheckoutDTO> CreateCheckout(CheckoutDTO checkoutDTO)
    {
        // Get customer - 1 query
        var customer = _unitOfWork.Customer.Get(checkoutDTO.Customer_id);
        if(customer == null)
        {
            return BadRequest(new ErrorDTO { Error = "Customer not found" });
        }

        // Calculate checkout price. PAYG -> do calculation. Return 0 otherwise
        var days = (float) (checkoutDTO.ReturnDate - DateTime.Now).TotalDays;
        var price = customer.MembershipTypeId != MembershipType.PayAsyouGo ? 0 : 10 * days;

        // Get all products - 1 query
        var products = _unitOfWork.Product.GetProductsFromRange(checkoutDTO.Items);
        foreach(var product in products)
        {
            if(product.Stock - 1 < 0)
            {
                return BadRequest(new ErrorDTO { Error = "Product " + product.Id + " out of stock" });
            }
        }

        // Add order and order item to context - 1 query
        var order = new Order
        {
            Price = price,
            Customer = customer,
            OrderItems = [.. checkoutDTO.Items.Select(i => new OrderItem { ProductId = i })],
            RentDate = DateTime.Now,
            ReturnDate = checkoutDTO.ReturnDate,
            Status = OrderStatus.PENDING
        };
        _unitOfWork.Order.Add(order);

        // Update stock
        foreach(var product in products)
        {
            product.Stock--;
        }

        _unitOfWork.Save();

        return Ok(checkoutDTO);
    }
}