namespace SLS.PM.Services;

public interface IRoomServices
{
	Task<ListResponse<RoomResponse>> GetAvailableRoomsForCommunityAsync(int communityId, int pageSize = 0, int pageIndex = 0);
	Task UpdateRoomAvailability(int roomId, int roomAvailabilityId);
}