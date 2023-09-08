using Barber.Api.Entities;

namespace Barber.Api.Models;
public class SchedulingToReturnDto{
  public int Id { get; set; }
  public DateTime? StartDate { get; set; }  = null;
  public DateTime? FinishDate { get; set; }  = null;
  public SchedulingStatus Status { get; set; }
  public DateTime? StartServiceDate { get; set; }  = null;
  public DateTime? FinishServiceDate { get; set; }  = null;
  public DateTime? ConfirmedDate { get; set; }  = null;
  public DateTime? CancellationDate { get; set; }  = null;
}