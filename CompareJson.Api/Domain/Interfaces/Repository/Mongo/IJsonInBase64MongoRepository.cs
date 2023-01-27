using CompareJson.Api.Domain.Entities;

namespace CompareJson.Api.Domain.Interfaces.Repository.Mongo
{
	public interface IJsonInBase64MongoRepository
	{
		Task InsertAsync(JsonInBase64 jsonInBase64);

		Task<JsonInBase64> GetJsonAsync(int id, string position);
		
	}
}