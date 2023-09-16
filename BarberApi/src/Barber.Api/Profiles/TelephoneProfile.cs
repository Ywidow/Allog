using AutoMapper;
using Barber.Api.Entities;
using Barber.Api.Models;

namespace Barber.Api.Profiles;

public class TelephoneProfile : Profile{
  public TelephoneProfile(){
    CreateMap<Telephone, TelephoneToReturnDto>().ReverseMap();
    CreateMap<TelephoneToCreateDto, TelephoneToReturnDto>().ReverseMap();
    CreateMap<TelephoneToCreateDto, Telephone>().ReverseMap();
    CreateMap<TelephoneToUpdateDto, Telephone>().ReverseMap();
    CreateMap<TelephoneTypeDto, TelephoneType>();
  }
}