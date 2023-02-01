using CompareJson.Domain.Entities;

namespace CompareJson.Domain.Interfaces.DomainService
{
	public interface IJsonInBase64CompareDomainService
	{
		public Task<ResultCompareJsonInBase64> CompareJsonInBase64Async(string? inputLeft, string? inputRight, int id);

		public Task<int> ProcessDiffsAsync(string? inputLeft, string? inputRight);

	}
}