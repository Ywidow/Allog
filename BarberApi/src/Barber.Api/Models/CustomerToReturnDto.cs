using Barber.Api.Entities;

namespace Barber.Api.Models;

public class CustomerToReturnDto{
  public int Id { get; set;}
  public string Name { get; set; } = string.Empty;
  public DateOnly BirthdayDate { get; set; }
  public Gender Gender { get; set; }
  public string CPF { get; set; } = string.Empty;
  public string Email { get; set; } = string.Empty;
  public IEnumerable<OrderToReturnDto> Orders { get; set; } = new List<OrderToReturnDto>();
  public IEnumerable<TelephoneToReturnDto> Telephones { get; set; } = new List<TelephoneToReturnDto>();
  public IEnumerable<AddressToReturnDto> Addresses { get; set; } = new List<AddressToReturnDto>();
  public IEnumerable<SchedulingToReturnDto> Schedulings { get; set; } = new List<SchedulingToReturnDto>();
}