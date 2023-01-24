using CompareJson.Api.Domain.Interfaces.Configurations;

namespace CompareJson.Api.Infrastructure.Data.Configurations
{
	public class DatabaseConfig : IDatabaseConfig
	{
		public string DatabaseName { get; set; }
		public string ConnectionString { get; set; }
	}
}
