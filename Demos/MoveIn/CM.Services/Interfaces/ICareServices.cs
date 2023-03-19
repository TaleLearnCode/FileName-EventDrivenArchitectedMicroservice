using CM.Services.Requests;

namespace CM.Services
{
	public interface ICareServices
	{
		Task ResidentMoveIn(ResidentMoveInRequest residentMoveInRequest);
	}
}