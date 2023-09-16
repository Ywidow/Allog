using AutoMapper;
using Barber.Api.Entities;
using Barber.Api.Models;

namespace Barber.Api.Profiles;

public class CustomerProfile : Profile{
  public CustomerProfile(){
    CreateMap<Customer, CustomerToReturnDto>().ReverseMap();
    CreateMap<Customer, CustomerWithTelephonesAndAddressesToReturnDto>().ReverseMap();
    CreateMap<CustomerToCreateDto, Customer>().ReverseMap();
    CreateMap<CustomerToCreateDto, CustomerWithTelephonesAndAddressesToReturnDto>().ReverseMap();
    CreateMap<CustomerWithTelephonesAndAddressesToReturnDto, Customer>().ReverseMap();
    CreateMap<CustomerToUpdate, Customer>().ReverseMap();
    CreateMap<Customer, CustomerWithTelephonesToReturnDto>().ReverseMap();

    CreateMap<Gender, GenderDto>().ReverseMap();
    CreateMap<Scheduling, SchedulingToReturnDto>().ReverseMap();
  }
}