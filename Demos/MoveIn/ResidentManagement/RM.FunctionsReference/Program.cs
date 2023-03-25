string? connectionString = Environment.GetEnvironmentVariable("RM-ConnectionString");
string? eventHubConnectionString = Environment.GetEnvironmentVariable("EventHubConnectionString");

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