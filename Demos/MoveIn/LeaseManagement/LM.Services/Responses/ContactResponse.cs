namespace SLS.LM.Services.Responses;

public class ContactResponse
{
  public int ContactId { get; set; }
  public string FirstName { get; set; } = null!;
  public string? MiddleName { get; set; }
  public string LastName { get; set; } = null!;
  public string? EmailAddress { get; set; } = null!;
}