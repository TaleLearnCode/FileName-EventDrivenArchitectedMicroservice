using Microsoft.EntityFrameworkCore;
using SLS.Common.Services;
using SLS.LM.Data;
using SLS.LM.Domain;
using SLS.LM.Services.Requests;
using SLS.LM.Services.Responses;

namespace SLS.LM.Services;

public class LeaseServices : ServicesBase, ILeaseServices
{

  public LeaseServices(string connectionString) : base(connectionString) { }

  public async Task<int> InitializeLeaseAsync(InitializeLeaseRequest request)
  {
    using LMContext lmContext = new(_connectionString);
    Lessee lessee = await CreateLesseeAsync(lmContext, request.Lessee);
    ResponsibleParty responsibleParty = await CreateResponsiblePartyAsync(lmContext, request.ResponsibleParty);
    Resident resident = await CreateResidentAsync(lmContext, request.Resident, lessee.LesseeId, responsibleParty.ResponsiblePartyId);
    Lease lease = await CreateLeaseAsync(lmContext, request.Lease, resident.ResidentId);
    return lease.LeaseId;
  }

  public async Task<LeaseResponse?> GetLeaseAsync(int leaseId)
  {
    using LMContext lmContext = new(_connectionString);
    Lease? lease = await lmContext.Leases
      .Include(x => x.LeaseType)
        .ThenInclude(x => x.LeaseTermType)
      .Include(x => x.Resident)
        .ThenInclude(x => x.Lessee)
      .Include(x => x.Resident)
        .ThenInclude(x => x.ResponsibleParty)
      .FirstOrDefaultAsync(x => x.LeaseId == leaseId);
    if (lease is not null)
    {
      return new()
      {
        LeaseId = lease.LeaseId,
        LeaseTypeId = lease.LeaseTypeId,
        LeaseType = lease.LeaseType.LeaseTypeName,
        LeaseTerm = lease.LeaseType.LeaseTermType.LeaseTermTypeName,
        StartDate = lease.StartDate,
        EndDate = lease.EndDate,
        Rate = lease.Rate,
        Resident = new()
        {
          ContactId = lease.Resident.ResidentId,
          FirstName = lease.Resident.FirstName ?? string.Empty,
          MiddleName = lease.Resident.MiddleName,
          LastName = lease.Resident.LastName
        },
        ResponsibleParty = new()
        {
          ContactId = lease.Resident.ResponsibleParty.ResponsiblePartyId,
          FirstName = lease.Resident.ResponsibleParty.FirstName ?? string.Empty,
          MiddleName = lease.Resident.ResponsibleParty.MiddleName,
          LastName = lease.Resident.ResponsibleParty.LastName,
          EmailAddress = lease.Resident.ResponsibleParty.EmailAddress
        },
        Lessee = new()
        {
          ContactId = lease.Resident.Lessee.LesseeId,
          FirstName = lease.Resident.Lessee.FirstName ?? string.Empty,
          MiddleName = lease.Resident.Lessee.MiddleName,
          LastName = lease.Resident.Lessee.LastName,
          EmailAddress = lease.Resident.Lessee.EmailAddress
        }
      };
    }
    return default;
  }

  private static async Task<Resident> CreateResidentAsync(LMContext lmContext, ResidentRequest residentRequest, int lesseeId, int responsiblePartyId)
  {
    Resident resident = new()
    {
      FirstName = residentRequest.FirstName,
      MiddleName = residentRequest.MiddleName,
      LastName = residentRequest.LastName,
      LesseeId = lesseeId,
      ResponsiblePartyId = responsiblePartyId
    };
    await lmContext.Residents.AddAsync(resident);
    await lmContext.SaveChangesAsync();
    return resident;
  }

  private static async Task<Lessee> CreateLesseeAsync(LMContext lmContext, ContactRequest contactRequest)
  {
    Lessee lessee = new()
    {
      FirstName = contactRequest.FirstName,
      MiddleName = contactRequest.MiddleName,
      LastName = contactRequest.LastName,
      EmailAddress = contactRequest.EmailAddress
    };
    await lmContext.AddRangeAsync(lessee);
    await lmContext.SaveChangesAsync();
    return lessee;
  }

  private static async Task<ResponsibleParty> CreateResponsiblePartyAsync(LMContext lmContext, ContactRequest contactRequest)
  {
    ResponsibleParty responsibleParty = new()
    {
      FirstName = contactRequest.FirstName,
      MiddleName = contactRequest.MiddleName,
      LastName = contactRequest.LastName,
      EmailAddress = contactRequest.EmailAddress
    };
    await lmContext.AddRangeAsync(responsibleParty);
    await lmContext.SaveChangesAsync();
    return responsibleParty;
  }

  private static async Task<Lease> CreateLeaseAsync(LMContext lmContext, LeaseRequest leaseRequest, int residentId)
  {
    Lease lease = new()
    {
      ResidentId = residentId,
      LeaseTypeId = leaseRequest.LeaseTypeId,
      StartDate = leaseRequest.StartDate,
      EndDate = leaseRequest.EndDate,
      Rate = leaseRequest.Rate
    };
    await lmContext.AddRangeAsync(lease);
    await lmContext.SaveChangesAsync();
    return lease;
  }

}