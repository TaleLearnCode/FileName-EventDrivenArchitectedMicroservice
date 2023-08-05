using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using SLS.RM.Services;
using SLS.RM.Services.Requests;
using System.Text.Json;
using TaleLearnCode;

namespace SLS.RM.Functions;

public class MoveInResident
{

	private readonly ILogger _logger;
	private readonly JsonSerializerOptions _jsonSerializerOptions;
	private readonly IResidentServices _residentServices;

	public MoveInResident(
		ILoggerFactory loggerFactory,
		JsonSerializerOptions jsonSerializerOptions,
		IResidentServices residentServices)
	{
		_logger = loggerFactory.CreateLogger<MoveInResident>();
		_jsonSerializerOptions = jsonSerializerOptions;
		_residentServices = residentServices;
	}

	[Function("ResidentMoveIn")]
	public async Task<HttpResponseData> RunAsync(
		[HttpTrigger(AuthorizationLevel.Function, "post", Route = "residents")] HttpRequestData request)
	{
		try
		{
			string? eventHubName = Environment.GetEnvironmentVariable("MoveInEventHubName") ?? throw new Exception("Failed to retrieve the event hub name.");
			MoveInRequest moveInRequest = await request.GetRequestParametersAsync<MoveInRequest>(_jsonSerializerOptions);
			int response = await _residentServices.MoveInResidentAsync(moveInRequest, eventHubName);
			return request.CreateCreatedResponse($"residents/{response}");
		}
		catch (Exception ex) when (ex is ArgumentNullException)
		{
			return request.CreateBadRequestResponse(ex);
		}
		catch (Exception ex)
		{
			_logger.LogError("Unexpected exception: {ExceptionMessage}", ex.Message);
			return request.CreateErrorResponse(ex);
		}
	}

}
