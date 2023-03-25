namespace SLS.RM.Functions.Functions;

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
			MoveInRequest moveInRequest = await request.GetRequestParametersAsync<MoveInRequest>(_jsonSerializerOptions);
			int response = await _residentServices.MoveInResidentAsync(moveInRequest);
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
