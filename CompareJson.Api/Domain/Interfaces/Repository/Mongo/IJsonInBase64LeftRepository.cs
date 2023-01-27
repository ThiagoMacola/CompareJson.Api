namespace CompareJson.Api.Domain.Interfaces.Repository.Mongo
{
	public interface IJsonInBase64LeftRepository
	{
		Task InsertAsync(Entities.JsonInBase64 jsonInBase64);

		Task<Entities.JsonInBase64> GetJsonAsync(int id);
		
	}
}
