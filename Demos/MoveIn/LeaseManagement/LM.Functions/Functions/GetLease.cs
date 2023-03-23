using System.Text.Json;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using SLS.LM.Services;
using SLS.LM.Services.Responses;
using TaleLearnCode;

namespace LM.API;

public class GetLease
{
  private readonly ILogger _logger;
  private readonly JsonSerializerOptions _jsonSerializerOptions;
  private readonly ILeaseServices _leaseServices;

  public GetLease(
    ILoggerFactory loggerFactory,
    JsonSerializerOptions jsonSerializerOptions,
    ILeaseServices leaseServices)
  {
    _logger = loggerFactory.CreateLogger<GetLease>();
    _jsonSerializerOptions = jsonSerializerOptions;
    _leaseServices = leaseServices;
  }

  [Function("GetCommunityResident")]
  public async Task<HttpResponseData> RunAsync(
    [HttpTrigger(AuthorizationLevel.Function, "get", Route = "leases/{leaseId}")] HttpRequestData request,
    int leaseId)
  {
    try
    {
      ArgumentNullException.ThrowIfNull(leaseId);
      LeaseResponse? response = await _leaseServices.GetLeaseAsync(leaseId);
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