using SLS.Common.Services.Responses;
using SLS.PM.Services;
using SLS.PM.Services.Responses;

RoomServices roomServices = new("Data Source=Beast;Initial Catalog=MoveIn-PM;Integrated Security=True");
ListResponse<RoomResponse> availableRooms = await roomServices.GetAvailableRoomsForCommunityAsync(22, 0, 0);
Console.WriteLine(availableRooms.TotalRecords);