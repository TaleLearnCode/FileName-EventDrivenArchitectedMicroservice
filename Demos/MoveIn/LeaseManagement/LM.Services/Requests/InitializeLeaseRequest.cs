namespace SLS.LM.Services.Requests;

public class InitializeLeaseRequest
{
  public LeaseRequest Lease { get; set; } = null!;
  public ResidentRequest Resident { get; set; } = null!;
  public ContactRequest Lessee { get; set; } = null!;
  public ContactRequest ResponsibleParty { get; set; } = null!;
}