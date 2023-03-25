string? connectionString = Environment.GetEnvironmentVariable("RM-ConnectionString");

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
			s.AddSingleton<IResidentServices>((s) => { return new ResidentServices(connectionString); });
	})
	.Build();

host.Run();