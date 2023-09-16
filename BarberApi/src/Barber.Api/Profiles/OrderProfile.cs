using AutoMapper;
using Barber.Api.Entities;
using Barber.Api.Models;

namespace Barber.Api.Profiles;

public class OrderProfile : Profile{
  public OrderProfile(){
    CreateMap<Order, OrderToReturnDto>().ReverseMap();
  }
}