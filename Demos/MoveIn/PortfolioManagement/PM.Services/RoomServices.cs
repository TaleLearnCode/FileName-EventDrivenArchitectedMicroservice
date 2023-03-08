using Microsoft.EntityFrameworkCore;
using SLS.Common.Services;
using SLS.Common.Services.Extensions;
using SLS.Common.Services.Responses;
using SLS.PM.Data;
using SLS.PM.Domain;
using SLS.PM.Services.Responses;

namespace SLS.PM.Services;

public class RoomServices : ServicesBase
{

	public RoomServices(string connectionString) : base(connectionString) { }

	public async Task<ListResponse<RoomResponse>> GetAvailableRoomsForCommunityAsync(
		int communityId,
		int pageSize = 0,
		int pageIndex = 0)
	{
		using PMContext pmContext = new(_connectionString);
		List<Room> availableRooms = await pmContext.Rooms
			.Include(x => x.Community)
				.ThenInclude(x => x.CommunityRoomTypes)
					.ThenInclude(x => x.FloorPlan)
			.Include(x => x.CommunityStructure)
			.Include(x => x.FloorPlan)
			.Include(x => x.AssignedCareType)
			.Include(x => x.RoomCareTypes)
				.ThenInclude(x => x.CareType)
			.Include(x => x.RoomAvailability)
			.Include(x => x.RoomType)
				.ThenInclude(x => x.RoomTypeCategory)
			.Include(x => x.RoomType)
				.ThenInclude(x => x.RoomStyle)
			.Include(x => x.RoomRates)
				.ThenInclude(x => x.PayorType)
			.Where(x => x.CommunityId == communityId && x.RoomAvailability.ShowAsAvailable)
			.ToListAsync();

		int pageCount = availableRooms.PageCount(pageSize);
		int totalRecords = availableRooms.Count;

		IList<RoomResponse>? items = default;

		if (availableRooms is not null && availableRooms.Any() && pageSize > 0 && pageIndex > 0)
			availableRooms = availableRooms.Page(pageIndex, pageSize).ToList();

		if (availableRooms is not null && availableRooms.Any())
		{
			items = new List<RoomResponse>();
			foreach (Room room in availableRooms)
			{
				items.Add(new()
				{
					RoomId = room.RoomId,
					RoomNumber = room.RoomNumber,
					RoomName = room.RoomName,
					RoomArea = room.RoomArea,
					Floorplan = GetFloorplanUrl(room),
					CommunityStructure = room.CommunityStructure.CommunityStructureName,
					Community = new()
					{
						Id = room.Community.CommunityId,
						Number = room.Community.CommunityNumber,
						Name = room.Community.CommunityName,
						ExternalName = room.Community.ExternalName
					},
					AssignedCareType = BuildAssignedCareTypeResponse(room),
					AvailableCareTypes = BuildAvailableCareTypesResponse(room),
					RoomAvailability = new()
					{
						Id = room.RoomAvailability.RoomAvailabilityId,
						Name = room.RoomAvailability.RoomAvailabilityName,
						BackgroundColor = room.RoomAvailability.BackgroundColor,
						ForegroundColor = room.RoomAvailability.ForegroundColor,
						ShowAsAvailable = room.RoomAvailability.ShowAsAvailable,
						ShowAsReserved = room.RoomAvailability.ShowAsReserved
					},
					RoomType = new()
					{
						Id = room.RoomType.RoomTypeId,
						Name = room.RoomType.RoomTypeName,
						RoomTypeCategory = new()
						{
							Id = room.RoomType.RoomTypeCategory?.RoomTypeCategoryId ?? int.MinValue,
							Name = room.RoomType.RoomTypeCategory?.RoomTypeCategoryName ?? string.Empty,
							Code = room.RoomType.RoomTypeCategory?.RoomTypeCategoryCode ?? string.Empty
						},
						RoomStyle = new()
						{
							Id = room.RoomType.RoomStyle.RoomStyleId,
							Name = room.RoomType.RoomStyle.RoomStyleName,
							Code = room.RoomType.RoomStyle.RoomStyleCode
						}
					},
					RoomRates = BuildRoomRatesResponse(room),
				});
			}
		}


		return new()
		{
			PageSize = pageSize,
			PageIndex = pageIndex,
			PageCount = pageCount,
			TotalRecords = totalRecords,
			RecordsReturned = (items is not null) ? items.Count : 0,
			Items = items
		};

	}

	private static Uri? GetFloorplanUrl(Room room)
	{
		if (room.FloorPlan is not null && room.FloorPlan.DigitalAssetUrl is not null)
			return room.FloorPlan.DigitalAssetUrl.ToUri();
		else if (room.Community.CommunityRoomTypes.FirstOrDefault(x => x.RoomTypeId == room.RoomTypeId)?.FloorPlan?.DigitalAssetUrl is not null)
			return room.Community.CommunityRoomTypes.FirstOrDefault(x => x.RoomTypeId == room.RoomTypeId)?.FloorPlan?.DigitalAssetUrl.ToUri();
		else
			return default;
	}

	private static CareTypeResponse? BuildAssignedCareTypeResponse(Room room)
		=> room.AssignedCareType switch
		{
			not null => new()
			{
				Name = room.AssignedCareType.CareTypeName,
				Code = room.AssignedCareType.CareTypeCode,
				ForegroundColor = room.AssignedCareType.ForegroundColor,
				BackgroundColor = room.AssignedCareType.BackgroundColor
			},
			_ => default
		};

	private static List<CareTypeResponse>? BuildAvailableCareTypesResponse(Room room)
	{
		if (room.RoomCareTypes is not null && room.RoomCareTypes.Any())
		{
			List<CareTypeResponse> response = new();
			foreach (CareType careType in room.RoomCareTypes.Select(x => x.CareType))
			{
				response.Add(new()
				{
					Name = careType.CareTypeName,
					Code = careType.CareTypeCode,
					ForegroundColor = careType.ForegroundColor,
					BackgroundColor = careType.BackgroundColor
				});
			}
			return response;

		}
		else
		{
			return new();
		}
	}

	private static Dictionary<string, RoomRateSummaryResponse> BuildRoomRatesResponse(Room room)
	{
		if (room.RoomRates is not null && room.RoomRates.Any())
		{
			Dictionary<string, RoomRateSummaryResponse> response = new();
			foreach (RoomRate roomRate in room.RoomRates)
			{
				response.TryAdd(roomRate.PayorType.PayorTypeName, new()
				{
					PayorTypeId = roomRate.PayorType.PayorTypeId,
					PayorTypeName = roomRate.PayorType.PayorTypeName,
					MonthlyRate = roomRate.BaseRate,
					DailyRate = roomRate.DailyRate
				});
			}
			return response;
		}
		else
		{
			return new();
		}
	}

}