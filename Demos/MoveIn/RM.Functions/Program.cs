using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SLS.RM.Services;
using System.Text.Json;
using System.Text.Json.Serialization;

string? connectionString = Environment.GetEnvironmentVariable("RM-ConnectionString");
string? eventHubConnectionString = "Endpoint=sb://guyroyse.servicebus.windows.net/;SharedAccessKeyName=ResidentMoveIn;SharedAccessKey=eNyj6dK1b/dTrFqQtqwB2naHC6pnRg9fb+AEhC1LW/A=;EntityPath=residentmovein";

var host = new HostBuilder()
	.ConfigureFunctionsWorkerDefaults()
	.ConfigureServices(s =>
	{
		s.AddSingleton((s) =>
		{
			return new JsonSerializerOptions()
			{
				PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
				DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
				DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
				WriteIndented = true
			};
		});
		if (connectionString is not null && eventHubConnectionString is not null)
			s.AddSingleton<IResidentServices>((s) => { return new ResidentServices(connectionString, eventHubConnectionString); });
	})
	.Build();

host.Run();