namespace CompareJson.Api.Domain.Interfaces.Configurations
{
    public interface IDatabaseConfig
    {
        string DatabaseName { get; set; }

        string ConnectionString { get; set; }

    }
}