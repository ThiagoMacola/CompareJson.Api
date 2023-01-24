namespace CompareJson.Api.Domain.Interfaces.Repository.Mongo
{
	public interface IJsonInBase64RightRepository
	{
		void Insert(Entities.JsonInBase64 jsonInBase64);

		Entities.JsonInBase64 GetJson(int id);
		
	}
}
