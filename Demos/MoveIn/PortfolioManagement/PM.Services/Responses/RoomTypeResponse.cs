namespace SLS.PM.Services.Responses;

public class RoomTypeResponse
{

	public int Id { get; set; }

	public string Name { get; set; } = null!;

	public RoomTypeCategoryResponse RoomTypeCategory { get; set; } = null!;

	public RoomStyleResponse RoomStyle { get; set; } = null!;

}