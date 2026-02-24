using APS.NET_Web.Models.OrderEntity.dto;
using ASP.NET_Web.DTO;
using ASP.NET_Web.Models.MembershipTypeEntity;
using ASP.NET_Web.Models.OrderEntity;
using ASP.NET_Web.Models.OrderEntity.Repo;
using ASP.NET_Web.Models.OrderItemEntity;
using ASP.NET_Web.Repo;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ASP.NET_Web.Controllers.API;

[ApiController]
[Route("api/checkout")]
public class CheckoutController(IUnitOfWork unitOfWork,  IMapper mapper) : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    [HttpPost]
    public ActionResult<CheckoutCompleteDTO> CreateCheckout(CheckoutDTO checkoutDTO)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(new ErrorDTO { Error = "Invalid request body." });
        }
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
        if(products.Count != checkoutDTO.Items.Count)
        {
            return BadRequest(new ErrorDTO { Error = "One or more products are invalid." });
        }

        // Add order and order item to context - 1 query
        var order = new Order
        {
            Price = price,
            Customer = customer,
            OrderItems = [.. checkoutDTO.Items.Select(i => new OrderItem { ProductId = i, Status = OrderStatus.CHECKOUT })],
            RentDate = DateTime.Now,
            ReturnDate = checkoutDTO.ReturnDate,
            Status = OrderStatus.CHECKOUT
        };
        _unitOfWork.Order.Add(order);

        // Update stock
        foreach(var product in products)
        {
            product.Stock--;
        }

        _unitOfWork.Save();

        var checkoutCompleteDTO = _mapper.Map<CheckoutCompleteDTO>(checkoutDTO);
        checkoutCompleteDTO.OrderId = order.Id;

        return Ok(checkoutCompleteDTO);
    }

    [HttpPost("return")]
    public ActionResult ReturnCheckout(ReturnDTO returnDTO)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(new ErrorDTO { Error = "Invalid request body." });
        }

        var order = _unitOfWork.Order.GetOrderWithProducts(returnDTO.OrderId);
        if(order == null)
        {
            return BadRequest(new ErrorDTO { Error = "Order not found." });
        }

        var products = _unitOfWork.Product.GetProductsFromRange(returnDTO.Items);
        if(products.Count != returnDTO.Items.Count)
        {
            return BadRequest(new ErrorDTO { Error = "One or more products are invalid." });
        }

        foreach(var product in products)
        {
            product.Stock++;
        }

        var totalReturn = 0;
        for(int i = 0; i < order.OrderItems.Count; i++)
        {
            if(returnDTO.Items.Contains(order.OrderItems[i].ProductId))
            {
                order.OrderItems[i].Status = OrderStatus.RETURN;
                totalReturn++;
            }
        }
        if(totalReturn == order.OrderItems.Count)
        {
            order.Status = OrderStatus.RETURN;
        }

        _unitOfWork.Save();

        return Ok();
    }
}