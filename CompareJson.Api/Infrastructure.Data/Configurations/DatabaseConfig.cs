using CompareJson.Api.Domain.Interfaces.Configurations;

namespace CompareJson.Api.Infrastructure.Data.Configurations
{
	public class DatabaseConfig : IDatabaseConfig
	{
		public DatabaseConfig(string databaseName, string connectionString)
		{
			DatabaseName = databaseName;
			ConnectionString = connectionString;
		}

		public string DatabaseName { get; set; }
		public string ConnectionString { get; set; }
	}
}
