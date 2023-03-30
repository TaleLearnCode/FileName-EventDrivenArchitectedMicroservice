using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SLS.LM.Services;
using System.Text.Json;
using System.Text.Json.Serialization;

string? connectionString = Environment.GetEnvironmentVariable("LM-ConnectionString");

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
		if (connectionString is not null)
			s.AddSingleton<ILeaseServices>((s) => { return new LeaseServices(connectionString); });
	})
	.Build();

host.Run();