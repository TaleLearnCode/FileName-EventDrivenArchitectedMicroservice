using SLS.CM.Services.Requests;
using SLS.CM.Services.Responses;

namespace SLS.CM.Services;

public interface ICareServices
{
	Task<ResidentResponse?> ResidentMoveIn(ResidentMoveInRequest residentMoveInRequest);
	Task<ResidentResponse?> GetCommunityResident(int communityId, int residentId);
	Task<ResidentCareTasks?> GetCareTasksForResident(int communityId, int residentId);
}