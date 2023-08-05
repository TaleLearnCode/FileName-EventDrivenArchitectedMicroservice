using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SLS.CM.Services;
using System.Text.Json;
using System.Text.Json.Serialization;

string? connectionString = Environment.GetEnvironmentVariable("CM-ConnectionString");

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
			s.AddSingleton<ICareServices>((s) => { return new CareServices(connectionString); });
	})
	.Build();

host.Run();