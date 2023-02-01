using CompareJson.Domain.Entities;
using CompareJson.Domain.Enum;
using CompareJson.Domain.Interfaces.DomainService;
using EnumsNET;
using Microsoft.Extensions.Logging;

namespace CompareJson.Domain.DomainService
{
	public class JsonInBase64CompareDomainService : IJsonInBase64CompareDomainService
	{
		private readonly ILogger<JsonInBase64CompareDomainService> _logger;

		public JsonInBase64CompareDomainService(ILoggerFactory loggerFactory)
		{
			_logger = loggerFactory.CreateLogger<JsonInBase64CompareDomainService>();

		}

		public async Task<ResultCompareJsonInBase64> CompareJsonInBase64Async(string? inputLeft, string? inputRight, int id)
		{
			try
			{
				_logger.LogInformation(@$"[{nameof(JsonInBase64CompareDomainService)}].CompareJsonInBase64Async - 
					Start.| Id = {id} | InputLeft={inputLeft} | InputLeft={inputRight}");

				var response = new ResultCompareJsonInBase64() { Id = id };

				if (inputLeft!.Equals(inputRight))
				{
					response.Result = Result.Equals.AsString(EnumFormat.Description);
					return response;
				}
				if (inputLeft.Length != inputRight!.Length)
				{
					response.Result = Result.DifferentSizes.AsString(EnumFormat.Description);
					return response;
				}

				response.Result = Result.Different.AsString(EnumFormat.Description);
				response.Length = await ProcessDiffsAsync(inputLeft, inputRight);

				_logger.LogInformation(@$"[{nameof(JsonInBase64CompareDomainService)}].CompareJsonInBase64Async - 
					End.| Id = {id} | InputLeft={inputLeft} | InputLeft={inputRight}");

				return response;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, @$"[{nameof(JsonInBase64CompareDomainService)}].CompareJsonInBase64Async - 
					Error.| Id = {id} | InputLeft={inputLeft} | InputLeft={inputRight}");
				throw;
			}
		}

		public Task<int> ProcessDiffsAsync(string? inputLeft, string? inputRight)
		{
			var leftArray = Convert.FromBase64String(inputLeft!);
			var rightArray = Convert.FromBase64String(inputRight!);

			var offsetList = new List<int>();

			for (int i = 1; i < leftArray.Length; i++)
			{
				if (leftArray[i] != rightArray[i])
				{
					offsetList.Add(i);
				}
			}
			return Task.FromResult(offsetList.Count);
		}
	}
}
