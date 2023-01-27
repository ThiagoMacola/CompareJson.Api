using CompareJson.Api.Domain.Entities;
using CompareJson.Api.Domain.Interfaces.Configurations;
using CompareJson.Api.Domain.Interfaces.Repository.Mongo;
using MongoDB.Driver;

namespace CompareJson.Api.Infrastructure.Data.Repositories.Mongo
{
	public class JsonRightRepository : IJsonInBase64RightRepository
	{
		private readonly IMongoCollection<JsonInBase64> _mongoCollection;

		public JsonRightRepository(IDatabaseConfig databaseConfig)
		{
			var client = new MongoClient(databaseConfig.ConnectionString);
			var database = client.GetDatabase(databaseConfig.DatabaseName);

			_mongoCollection = database.GetCollection<JsonInBase64>("JsonInBase64Left");
		}

		public async Task<JsonInBase64> GetJsonAsync(int id) => 
			await _mongoCollection.Find(json => json.Id == id).FirstOrDefaultAsync();
	
		public async Task InsertAsync(JsonInBase64 jsonInBase64) => 
			await _mongoCollection.InsertOneAsync(jsonInBase64);
	}
}