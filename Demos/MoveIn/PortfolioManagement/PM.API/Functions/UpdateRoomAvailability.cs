namespace PM.API.Functions;

public class UpdateRoomAvailability
{

	private readonly ILogger _logger;
	private readonly IRoomServices _roomServices;

	public UpdateRoomAvailability(
		ILoggerFactory loggerFactory,
		IRoomServices roomServices)
	{
		_logger = loggerFactory.CreateLogger<UpdateRoomAvailability>();
		_roomServices = roomServices;
	}

	[Function("UpdateRoomAvailability")]
	public async Task<HttpResponseData> RunAsync(
		[HttpTrigger(AuthorizationLevel.Function, "put", Route = "rooms/{roomId}/room-availability/{roomAvailabilityId}")] HttpRequestData request,
		int roomId,
		int roomAvailabilityId)
	{
		ArgumentNullException.ThrowIfNull(roomId);
		ArgumentNullException.ThrowIfNull(roomAvailabilityId);
		try
		{
			await _roomServices.UpdateRoomAvailability(roomId, roomAvailabilityId);
			return request.CreateResponse(HttpStatusCode.OK);
		}
		catch (Exception ex) when (ex is ArgumentNullException)
		{
			return request.CreateBadRequestResponse(ex);
		}
		catch (Exception ex) when (ex is ArgumentOutOfRangeException)
		{
			return request.CreateResponse(HttpStatusCode.NotFound, ex.Message);
		}
		catch (Exception ex)
		{
			_logger.LogError("Unexpected exception: {ExceptionMessage}", ex.Message);
			return request.CreateErrorResponse(ex);
		}
	}
}
