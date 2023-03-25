using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using SLS.Common.Services.EventMessages;
using SLS.LM.Services;
using System.Text.Json;

namespace LM.EventHandler_Reference;

public class ResidentMoveIn
{

	private readonly ILogger _logger;
	private readonly JsonSerializerOptions _jsonSerializerOptions;
	private readonly ILeaseServices _leaseServices;

	public ResidentMoveIn(
		ILoggerFactory loggerFactory,
		JsonSerializerOptions jsonSerializerOptions,
		ILeaseServices leaseServices)
	{
		_logger = loggerFactory.CreateLogger<ResidentMoveIn>();
		_jsonSerializerOptions = jsonSerializerOptions;
		_leaseServices = leaseServices;
	}

	[Function("LM-ResidentMoveIn")]
	public async Task RunAsync([EventHubTrigger("%MoveInEventHubName%", Connection = "EventHubConnectionString", ConsumerGroup = "lease")] string[] messages)
	{
		foreach (string message in messages)
		{
			ResidentMoveInEventMessage? residentMoveInEventMessage = JsonSerializer.Deserialize<ResidentMoveInEventMessage>(message);
			if (residentMoveInEventMessage is not null)
			{
				_logger.LogInformation($"Processing Event Message: {residentMoveInEventMessage.MessageId}");
				await _leaseServices.InitializeLeaseAsync(new(residentMoveInEventMessage));
			}
		}
	}

}