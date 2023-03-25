namespace SLS.RM.Services;

public interface IResidentServices
{
	Task<ResidentResponse?> GetResidentAsync(int residentId);
	Task<int> MoveInResidentAsync(MoveInRequest moveInRequest, string eventHubName);
}