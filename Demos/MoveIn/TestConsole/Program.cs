using CM.Services;

//RoomServices roomServices = new("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MoveIn-PM;Integrated Security=True");
//ListResponse<RoomResponse> availableRooms = await roomServices.GetAvailableRoomsForCommunityAsync(22, 0, 0);
//Console.WriteLine(availableRooms.TotalRecords);


CareServices careServices = new("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MoveIn-CM;Integrated Security=True");
//await careServices.ResidentMoveIn(new()
//{
//	ResidentId = 9999,
//	CommunityId = 22,
//	RoomId = 1254,
//	CareTypeId = 3,
//	FirstName = "Laura",
//	MiddleName = "Jean",
//	LastName = "Green",
//	DateOfBirth = new(1946, 8, 15),
//	AncillaryCares = new() { 1, 11 }
//});

await careServices.ResidentMoveIn(new()
{
	ResidentId = 9998,
	CommunityId = 22,
	RoomId = 1254,
	CareTypeId = 3,
	FirstName = "Edwin",
	MiddleName = "Elliott",
	LastName = "Green",
	DateOfBirth = new(1946, 3, 12),
	AncillaryCares = new() { 1, 11 }
});