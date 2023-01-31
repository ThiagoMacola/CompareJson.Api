using CompareJson.Domain.Entities;
using CompareJson.Domain.Interfaces.Repository.InMemory;
using CompareJson.Infrastructure.Data.DatabaseContext;

namespace CompareJson.Infrastructure.Data.Repositories.InMemory
{
	public class JsonBase64Repository : IJsonBase64Repository
	{
		private readonly JsonBase64Context _context;

		public JsonBase64Repository(JsonBase64Context jsonBase64Context)
		{
			_context = jsonBase64Context;
		}

		public async Task<bool> AddOrUpdateJsonAsync(JsonInBase64 jsonInBase64)
		{
			JsonInBase64 jsonExist = await SelectAsync(jsonInBase64.Id, jsonInBase64.Position);

			if (jsonExist is null)
				await _context.AddAsync(jsonInBase64);
			else
				jsonExist.Base64 = jsonInBase64.Base64;

			await _context.SaveChangesAsync();

			return await Task.FromResult(true);
		}

		public async Task<JsonInBase64> SelectAsync(int id, string position) =>
			 await _context.JsonInBase64.FindAsync(id, position);
	}
}
