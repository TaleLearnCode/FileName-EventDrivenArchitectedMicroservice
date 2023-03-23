namespace SLS.LM.Services.Requests;

public class ResidentRequest
{
  public string FirstName { get; set; } = null!;
  public string? MiddleName { get; set; }
  public string LastName { get; set; } = null!;
}