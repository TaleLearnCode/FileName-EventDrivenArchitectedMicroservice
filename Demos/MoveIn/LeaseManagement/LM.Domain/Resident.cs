namespace SLS.LM.Domain;

public partial class Resident
{
  public Resident()
  {
    Leases = new HashSet<Lease>();
  }

  public int ResidentId { get; set; }
  public string? FirstName { get; set; }
  public string? MiddleName { get; set; }
  public string LastName { get; set; } = null!;
  public int LesseeId { get; set; }
  public int ResponsiblePartyId { get; set; }

  public virtual Lessee Lessee { get; set; } = null!;
  public virtual ResponsibleParty ResponsibleParty { get; set; } = null!;
  public virtual ICollection<Lease> Leases { get; set; }
}