namespace Barber.Api.Entities;

public enum Gender{ Masc, Fem }

public class Customer{
  public int Id { get; set;}
  public string Name { get; set; } = string.Empty;
  public DateOnly BirthdayDate { get; set; }
  public Gender Gender { get; set; }
  public string CPF { get; set; } = string.Empty;
  public string Email { get; set; } = string.Empty;
  public IEnumerable<Order> Orders { get; set; } = new List<Order>();
  public IEnumerable<Telephone> Telephones { get; set; } = new List<Telephone>();
  public IEnumerable<Address> Addresses { get; set; } = new List<Address>();
  public IEnumerable<Scheduling> Schedulings { get; set; } = new List<Scheduling>();
}