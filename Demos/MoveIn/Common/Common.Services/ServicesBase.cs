namespace SLS.Common.Services;

public abstract class ServicesBase
{

	protected readonly string _connectionString;

	protected ServicesBase(string connectionString) => _connectionString = connectionString;


}