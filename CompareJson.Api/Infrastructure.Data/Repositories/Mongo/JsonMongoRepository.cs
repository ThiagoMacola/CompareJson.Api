using CompareJson.Api.Domain.Entities;
using CompareJson.Api.Domain.Interfaces.Configurations;
using CompareJson.Api.Domain.Interfaces.Repository.Mongo;
using MongoDB.Driver;

namespace CompareJson.Api.Infrastructure.Data.Repositories.Mongo
{
	public class JsonMongoRepository : IJsonInBase64MongoRepository
	{
		private readonly IMongoCollection<JsonInBase64> _mongoCollection;

		public JsonMongoRepository(IDatabaseConfig databaseConfig)
		{
			var client = new MongoClient(databaseConfig.ConnectionString);
			var database = client.GetDatabase(databaseConfig.DatabaseName);

			_mongoCollection = database.GetCollection<JsonInBase64>("JsonInBase64");
		}

		public async Task<JsonInBase64> GetJsonAsync(int id, string position) => 
			 await _mongoCollection.Find(json => json.Id == id && json.Position == position).FirstOrDefaultAsync();
	
		public async Task InsertAsync(JsonInBase64 jsonInBase64) => 
			await _mongoCollection.InsertOneAsync(jsonInBase64);
		
	}
}