﻿using CompareJson.Api.Domain.Entities;

namespace CompareJson.Api.Domain.Interfaces.Repository.InMemory
{
	public interface IJsonBase64Repository
	{
		Task<bool> AddOrUpdateJsonAsync(JsonInBase64 jsonInBase64);

		Task<JsonInBase64> SelectAsync(int id, string position);
	}
}
