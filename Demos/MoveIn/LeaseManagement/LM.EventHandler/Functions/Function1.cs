using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace LM.EventHandler
{
	public class Function1
	{
		private readonly ILogger _logger;

		public Function1(ILoggerFactory loggerFactory)
		{
			_logger = loggerFactory.CreateLogger<Function1>();
		}

		[Function("Function1")]
		public void Run([EventHubTrigger("%MoveInEventHubName%", Connection = "EventHubConnectionString")] string[] messages)
		{
			_logger.LogInformation($"First Event Hubs triggered message: {messages[0]}");
		}
	}
}
