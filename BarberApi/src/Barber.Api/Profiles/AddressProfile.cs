using AutoMapper;
using Barber.Api.Entities;
using Barber.Api.Models;

namespace Barber.Api.Profiles;

public class AddressProfile : Profile{
  public AddressProfile(){
    CreateMap<Address, AddressToReturnDto>().ReverseMap();
    CreateMap<AddressToCreateDto, Address>().ReverseMap();
    CreateMap<AddressToCreateDto, AddressToReturnDto>().ReverseMap();
    CreateMap<Address, AddressToUpdateDto>().ReverseMap();
  }
}