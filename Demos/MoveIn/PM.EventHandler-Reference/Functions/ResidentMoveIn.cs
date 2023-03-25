using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using SLS.Common.Services.EventMessages;

namespace PM.EventHandler_Reference;

public class ResidentMoveIn
{

	private readonly ILogger _logger;
	private readonly JsonSerializerOptions _jsonSerializerOptions;
	private readonly IRoomServices _roomServices;

	private const int _roomOccupied = 1;

	public ResidentMoveIn(
		ILoggerFactory loggerFactory,
		JsonSerializerOptions jsonSerializerOptions,
		IRoomServices roomServices)
	{
		_logger = loggerFactory.CreateLogger<ResidentMoveIn>();
		_jsonSerializerOptions = jsonSerializerOptions;
		_roomServices = roomServices;
	}

	[Function("PM-ResidentMoveIn")]
	public async Task RunAsync([EventHubTrigger("%MoveInEventHubName%", Connection = "EventHubConnectionString", ConsumerGroup = "portfolio")] string[] messages)
	{
		foreach (string message in messages)
		{
			ResidentMoveInEventMessage? residentMoveInEventMessage = JsonSerializer.Deserialize<ResidentMoveInEventMessage>(message);
			if (residentMoveInEventMessage is not null)
			{
				_logger.LogInformation($"Processing Event Message: {residentMoveInEventMessage.MessageId}");
				foreach (int roomId in residentMoveInEventMessage.Rooms.Select(x => x.RoomId))
					await _roomServices.UpdateRoomAvailability(roomId, _roomOccupied);
			}
		}
	}

}