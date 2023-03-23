using System.Text.Json;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using SLS.LM.Services;
using SLS.LM.Services.Requests;
using TaleLearnCode;

namespace LM.API.Functions;
public class InitializeLease
{
  private readonly ILogger _logger;
  private readonly JsonSerializerOptions _jsonSerializerOptions;
  private readonly ILeaseServices _leaseServices;

  public InitializeLease(
    ILoggerFactory loggerFactory,
    JsonSerializerOptions jsonSerializerOptions,
    ILeaseServices leaseServices)
  {
    _logger = loggerFactory.CreateLogger<InitializeLease>();
    _jsonSerializerOptions = jsonSerializerOptions;
    _leaseServices = leaseServices;
  }

  [Function("InitializeLease")]
  public async Task<HttpResponseData> RunAsync(
    [HttpTrigger(AuthorizationLevel.Function, "post", Route = "leases")] HttpRequestData request)
  {
    try
    {
      InitializeLeaseRequest residentMoveInRequest = await request.GetRequestParametersAsync<InitializeLeaseRequest>(_jsonSerializerOptions);
      int response = await _leaseServices.InitializeLeaseAsync(residentMoveInRequest);
      return request.CreateCreatedResponse($"/leases/{response}");
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