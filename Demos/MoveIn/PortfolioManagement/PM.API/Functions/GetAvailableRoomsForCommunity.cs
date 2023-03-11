namespace PM.API.Functions;

public class GetAvailableRoomsForCommunity
{

	private readonly ILogger _logger;
	private readonly JsonSerializerOptions _jsonSerializerOptions;
	private readonly IRoomServices _roomServices;

	public GetAvailableRoomsForCommunity(
		ILoggerFactory loggerFactory,
		JsonSerializerOptions jsonSerializerOptions,
		IRoomServices roomServices)
	{
		_logger = loggerFactory.CreateLogger<GetAvailableRoomsForCommunity>();
		_jsonSerializerOptions = jsonSerializerOptions;
		_roomServices = roomServices;
	}

	[Function("GetAvailableRoomsForCommunity")]
	public async Task<HttpResponseData> RunAsync(
		[HttpTrigger(AuthorizationLevel.Function, "get", Route = "communities/{communityId}/rooms/available")] HttpRequestData request,
		int communityId)
	{
		try
		{
			ArgumentNullException.ThrowIfNull(communityId);
			ListResponse<RoomResponse> response = await _roomServices.GetAvailableRoomsForCommunityAsync(
				communityId,
				request.GetInt32QueryStringValue("pageSize", 0),
				request.GetInt32QueryStringValue("pageIndex", 0));
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