namespace SLS.LM.Services.Requests;

public class ContactRequest
{
  public string FirstName { get; set; } = null!;
  public string? MiddleName { get; set; }
  public string LastName { get; set; } = null!;
  public string? EmailAddress { get; set; } = null!;
}