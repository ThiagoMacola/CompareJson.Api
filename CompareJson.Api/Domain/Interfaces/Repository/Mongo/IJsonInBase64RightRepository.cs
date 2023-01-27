using CompareJson.Api.Domain.Entities;

namespace CompareJson.Api.Domain.Interfaces.Repository.Mongo
{
	public interface IJsonInBase64RightRepository
	{
		Task InsertAsync(Entities.JsonInBase64 jsonInBase64);
		Task<JsonInBase64> GetJsonAsync(int id);

	}
}
