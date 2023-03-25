namespace SLS.RM.Functions;

public class GetResident
{

	private readonly ILogger _logger;
	private readonly JsonSerializerOptions _jsonSerializerOptions;
	private readonly IResidentServices _residentServices;

	public GetResident(
		ILoggerFactory loggerFactory,
		JsonSerializerOptions jsonSerializerOptions,
		IResidentServices residentServices)
	{
		_logger = loggerFactory.CreateLogger<GetResident>();
		_jsonSerializerOptions = jsonSerializerOptions;
		_residentServices = residentServices;
	}

	[Function("GetResident")]
	public async Task<HttpResponseData> RunAsync(
		[HttpTrigger(AuthorizationLevel.Function, "get", Route = "residents/{residentId}")] HttpRequestData request,
		int residentId)
	{
		try
		{
			ArgumentNullException.ThrowIfNull(residentId);
			ResidentResponse? response = await _residentServices.GetResidentAsync(residentId);
			return await request.CreateResponseAsync(response, _jsonSerializerOptions);
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