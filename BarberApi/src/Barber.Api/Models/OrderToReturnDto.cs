using Barber.Api.Entities;

namespace Barber.Api.Models;

public class OrderToReturnDto{
  public int Id { get; set;}
  public int Number { get; set; }
  public Status Status { get; set; }
  public DateOnly BuyDate { get; set; }
  public PaymentMethod PaymentMethod { get; set; }
  public string Observations { get; set; } = string.Empty;
}