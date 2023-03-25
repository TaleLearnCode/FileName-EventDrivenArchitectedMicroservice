using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using SLS.CM.Services.Requests;
using SLS.CM.Services.Responses;
using TaleLearnCode;

namespace SLS.CM.Functions;

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
		_logger = loggerFactory.CreateLogger<GetCommunityResident>();
		_jsonSerializerOptions = jsonSerializerOptions;
		_careServices = careServices;
	}

	[Function("ResidentMoveIn")]
	public async Task<HttpResponseData> RunAsync(
		[HttpTrigger(AuthorizationLevel.Function, "post", Route = "communities/{communityId}/residents/")] HttpRequestData request,
		int communityId)
	{
		try
		{
			ArgumentNullException.ThrowIfNull(communityId);
			ResidentMoveInRequest residentMoveInRequest = await request.GetRequestParametersAsync<ResidentMoveInRequest>(_jsonSerializerOptions);
			ResidentResponse? response = await _careServices.ResidentMoveIn(residentMoveInRequest);
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
