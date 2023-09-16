namespace Barber.Api.Entities;

public enum Status{ Payed, NotPayed }

public enum PaymentMethod {
  Credit,
  Debit,
  PIX,
  Bolet,
  Money,
  CriptCoins,
  Check,
  Voucher, 
}

public class Order{
  public int Id { get; set;}
  public int Number { get; set; }
  public Status Status { get; set; }
  public DateOnly BuyDate { get; set; }
  public PaymentMethod PaymentMethod { get; set; }
  public string Observations { get; set; } = string.Empty;
  public int CustomerId { get; set; }
  public Customer? Customer { get; set; }
}