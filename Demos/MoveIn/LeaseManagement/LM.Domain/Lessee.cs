namespace SLS.LM.Domain;

public partial class Lessee
{
  public Lessee()
  {
    Residents = new HashSet<Resident>();
  }

  public int LesseeId { get; set; }
  public string? ExternalId { get; set; }
  public string? FirstName { get; set; }
  public string? MiddleName { get; set; }
  public string LastName { get; set; } = null!;
  public string? EmailAddress { get; set; }

  public virtual ICollection<Resident> Residents { get; set; }
}