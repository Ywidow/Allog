using AutoMapper;
using Barber.Api.Entities;
using Barber.Api.Models;

namespace Barber.Api.Profiles;

public class CustomerProfile : Profile{
  public CustomerProfile(){
    CreateMap<Customer, CustomerToReturnDto>().ReverseMap();
    CreateMap<Order, OrderToReturnDto>().ReverseMap();
    CreateMap<Telephone, TelephoneToReturnDto>().ReverseMap();
    CreateMap<Address, AddressToReturnDto>().ReverseMap();
    CreateMap<Scheduling, SchedulingToReturnDto>().ReverseMap();
  }
}