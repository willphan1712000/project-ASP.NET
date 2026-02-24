using AutoMapper;

namespace APS.NET_Web.Models.OrderEntity.dto;

public class CheckoutProfile: Profile
{
    public CheckoutProfile()
    {
        CreateMap<CheckoutDTO, CheckoutCompleteDTO>();
    }    
}