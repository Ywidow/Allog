namespace Barber.Api.Entities;

public class TelephoneToReturnDto{
  public int Id { get; set; }
  public string Number { get; set; } = string.Empty;
  public TelephoneType Type { get; set; }
}