using SLS.LM.Services.Requests;
using SLS.LM.Services.Responses;

namespace SLS.LM.Services
{
  public interface ILeaseServices
  {
    Task<LeaseResponse?> GetLeaseAsync(int leaseId);
    Task<int> InitializeLeaseAsync(InitializeLeaseRequest request);
  }
}