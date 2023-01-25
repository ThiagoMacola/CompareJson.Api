using CompareJson.Api.Domain.Entities;
using CompareJson.Api.Domain.Interfaces.Configurations;
using CompareJson.Api.Domain.Interfaces.Repository.Mongo;
using MongoDB.Driver;

namespace CompareJson.Api.Infrastructure.Data.Repositories.Mongo
{
	public class JsonLeftRepository : IJsonInBase64LeftRepository
	{
		private readonly IMongoCollection<JsonInBase64> _mongoCollection;

		public JsonLeftRepository(IDatabaseConfig databaseConfig)
		{
			var client = new MongoClient(databaseConfig.ConnectionString);
			var database = client.GetDatabase(databaseConfig.DatabaseName);

			_mongoCollection = database.GetCollection<JsonInBase64>("JsonInBase64Left");
		}

		public async Task<JsonInBase64> GetJsonAsync(int id)
		{
			return (JsonInBase64)await _mongoCollection.FindAsync(json => json.Id == id);
		}

		public void Insert(JsonInBase64 jsonInBase64)
		{
			_mongoCollection.InsertOneAsync(jsonInBase64);
		}

	}
}
