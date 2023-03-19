using CM.Services.Requests;
using Microsoft.EntityFrameworkCore;
using SLS.CM.Data;
using SLS.CM.Domain;
using SLS.Common.Services;

namespace CM.Services;

public class CareServices : ServicesBase, ICareServices
{

	public CareServices(string connectionString) : base(connectionString) { }

	public async Task ResidentMoveIn(ResidentMoveInRequest residentMoveInRequest)
	{
		using CMContext cmContext = new(_connectionString);
		Resident? resident = await UpsertResident(cmContext, residentMoveInRequest);
		if (resident is not null)
		{
			await AssignResidentToCommunityAsync(residentMoveInRequest, cmContext, resident);
			ResidentCommunity residentCommunity = resident.ResidentCommunities.First(x => x.CommunityId == residentMoveInRequest.CommunityId);
			await AssignResidentToRoomAsync(cmContext, residentCommunity, residentMoveInRequest);
			await AssignResidentAncillaryCares(residentMoveInRequest, cmContext, residentCommunity);
		}
	}

	private static async Task AssignResidentAncillaryCares(ResidentMoveInRequest residentMoveInRequest, CMContext cmContext, ResidentCommunity residentCommunity)
	{
		if (residentMoveInRequest.AncillaryCares is not null && residentMoveInRequest.AncillaryCares.Any())
		{
			if (residentCommunity.ResidentAncillaryCares is not null && residentCommunity.ResidentAncillaryCares.Any())
			{
				foreach (ResidentAncillaryCare residentAncillaryCare in residentCommunity.ResidentAncillaryCares)
				{
					if (!residentMoveInRequest.AncillaryCares.Contains(residentAncillaryCare.AncillaryCareId))
					{
						residentCommunity.ResidentAncillaryCares.Remove(residentAncillaryCare);
					}
				}
			}
			foreach (int ancillaryCareId in residentMoveInRequest.AncillaryCares)
			{
				if (!IsResidentAssignedAncillaryCare(residentCommunity.ResidentAncillaryCares, ancillaryCareId))
				{
					residentCommunity.ResidentAncillaryCares?.Add(new()
					{
						AncillaryCareId = ancillaryCareId
					});
				}
			}
			await cmContext.SaveChangesAsync();
		}
	}

	private static async Task AssignResidentToRoomAsync(CMContext cmContext, ResidentCommunity residentCommunity, ResidentMoveInRequest residentMoveInRequest)
	{
		if (!IsResidentAssignedToRoom(residentCommunity.ResidentRooms, residentMoveInRequest.RoomId))
		{
			residentCommunity.ResidentRooms.Add(new()
			{
				RoomId = residentMoveInRequest.RoomId,
				CareTypeId = residentMoveInRequest.CareTypeId
			});
			await cmContext.SaveChangesAsync();
		}
	}

	private static async Task AssignResidentToCommunityAsync(ResidentMoveInRequest residentMoveInRequest, CMContext cmContext, Resident? resident)
	{
		if (!IsResidentAssignedToCommunity(resident?.ResidentCommunities, residentMoveInRequest.CommunityId))
		{
			resident?.ResidentCommunities.Add(new()
			{
				CommunityId = residentMoveInRequest.CommunityId
			});
			await cmContext.SaveChangesAsync();
		}
	}

	private static async Task<Resident?> UpsertResident(CMContext cmContext, ResidentMoveInRequest residentMoveInRequest)
	{
		Resident? resident = await cmContext.Residents
			.Include(x => x.ResidentCommunities)
				.ThenInclude(x => x.ResidentRooms)
			.Include(x => x.ResidentCommunities)
				.ThenInclude(x => x.ResidentAncillaryCares)
			.FirstOrDefaultAsync(x => x.ResidentId == residentMoveInRequest.ResidentId);
		if (resident is not null)
		{
			resident.FirstName = residentMoveInRequest.FirstName;
			resident.MiddleName = residentMoveInRequest.MiddleName;
			resident.LastName = residentMoveInRequest.LastName;
			resident.DateOfBirth = residentMoveInRequest.DateOfBirth.ToDateTime(new TimeOnly());
		}
		else
		{
			resident = new()
			{
				FirstName = residentMoveInRequest.FirstName,
				MiddleName = residentMoveInRequest.MiddleName,
				LastName = residentMoveInRequest.LastName,
				DateOfBirth = residentMoveInRequest.DateOfBirth.ToDateTime(new TimeOnly())
			};
			await cmContext.Residents.AddAsync(resident);
		}
		await cmContext.SaveChangesAsync();
		return resident;
	}

	private static bool IsResidentAssignedToCommunity(ICollection<ResidentCommunity>? residentCommunities, int communityId)
		=> residentCommunities is not null && residentCommunities.FirstOrDefault(x => x.CommunityId == communityId) is not null;

	private static bool IsResidentAssignedToRoom(ICollection<ResidentRoom>? residentRooms, int roomId)
		=> residentRooms is not null && residentRooms.FirstOrDefault(x => x.RoomId == roomId) is not null;

	private static bool IsResidentAssignedAncillaryCare(ICollection<ResidentAncillaryCare>? residentAncillaryCares, int ancillaryCareId)
		=> residentAncillaryCares is not null && residentAncillaryCares.FirstOrDefault(x => x.AncillaryCareId == ancillaryCareId) is not null;

}