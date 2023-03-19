using CM.Services.Requests;
using CM.Services.Responses;

namespace CM.Services;

public interface ICareServices
{
	Task<ResidentResponse?> ResidentMoveIn(ResidentMoveInRequest residentMoveInRequest);
	Task<ResidentResponse?> GetCommunityResident(int communityId, int residentId);
}