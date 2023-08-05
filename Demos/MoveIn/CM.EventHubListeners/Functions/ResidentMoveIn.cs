using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using SLS.CM.Services;
using SLS.CM.Services.Responses;
using SLS.Common.Services.EventMessages;
using System.Text.Json;

namespace SLS.CM.EventHandler;

public class ResidentMoveIn
{

	private readonly ILogger _logger;
	private readonly JsonSerializerOptions _jsonSerializerOptions;
	private readonly ICareServices _careServices;

	public ResidentMoveIn(
		ILoggerFactory loggerFactory,
		JsonSerializerOptions jsonSerializerOptions,
		ICareServices careServices)
	{
		_logger = loggerFactory.CreateLogger<ResidentMoveIn>();
		_jsonSerializerOptions = jsonSerializerOptions;
		_careServices = careServices;
	}

	[Function("CM-ResidentMoveIn")]
	public async Task RunAsync(
		[EventHubTrigger("%MoveInEventHubName%", Connection = "EventHubConnectionString", ConsumerGroup = "care")] string[] messages)
	{
		foreach (string message in messages)
		{
			ResidentMoveInEventMessage? residentMoveInEventMessage = JsonSerializer.Deserialize<ResidentMoveInEventMessage>(message);
			ResidentResponse? residentResponse = default;
			if (residentMoveInEventMessage is not null)
			{
				_logger.LogInformation($"Processing Event Message: {residentMoveInEventMessage.MessageId}");
				foreach (int roomId in residentMoveInEventMessage.Rooms.Select(x => x.RoomId))
				{
					residentResponse = await _careServices.ResidentMoveIn(new(residentMoveInEventMessage, roomId));
				}
				if (residentResponse is not null)
					await _careServices.AssignCareTaskToNewResidentAsync(residentMoveInEventMessage.CommunityId, residentResponse.ResidentId);
			}

		}
	}
}
