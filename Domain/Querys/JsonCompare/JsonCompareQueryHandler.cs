using AutoMapper;
using ComparaJson.CrossCutting.Configuration.Helpers;
using CompareJson.CrossCutting.Exceptions;
using CompareJson.Domain.Commands.JsonInBase64Left;
using CompareJson.Domain.Entities;
using CompareJson.Domain.Enum;
using CompareJson.Domain.Interfaces.DomainService;
using CompareJson.Domain.Interfaces.Repository.InMemory;
using EnumsNET;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CompareJson.Domain.Querys.JsonCompare
{
	public class JsonCompareQueryHandler : IRequestHandler<JsonCompareQuery, JsonCompareQueryResponse>
	{

		private readonly IMapper _mapper;
		private readonly ILogger _logger;
		private readonly IJsonBase64Repository _jsonBase64Repository;
		private readonly IJsonInBase64CompareDomainService _jsonInBase64CompareDomainService;

		public JsonCompareQueryHandler
		(
			IMapper mapper,
			ILoggerFactory loggerFactorty,
			IJsonBase64Repository jsonBase64Repository,
			IJsonInBase64CompareDomainService jsonInBase64CompareDomainService
		)
		{
			_mapper = mapper;
			_logger = loggerFactorty.CreateLogger<JsonCompareQueryHandler>();
			_jsonBase64Repository = jsonBase64Repository;
			_jsonInBase64CompareDomainService = jsonInBase64CompareDomainService;

		}

		public async Task<JsonCompareQueryResponse> Handle(JsonCompareQuery query, CancellationToken cancellationToken)
		{
			try
			{
				_logger.LogInformation($@"[{nameof(JsonInBase64LeftCommandHandler)}].Handle - 
                    Start.| Id={query.Id}");

				var inputLeft = await _logger.Measure(async () => await _jsonBase64Repository.SelectAsync(query.Id, Position.Left.ToString()), "GetJsonAsyncLeft");

				var inputRight = await _logger.Measure(async () => await _jsonBase64Repository.SelectAsync(query.Id, Position.Right.ToString()), "GetJsonAsyncRight");

				if (inputLeft == null || inputRight == null)
					throw new JsonNotFoundException();

				var comparedJson = await _jsonInBase64CompareDomainService.CompareJsonInBase64Async(inputLeft.Base64, inputRight.Base64, query.Id);

				var response = _mapper.Map<JsonCompareQueryResponse>(comparedJson);

				_logger.LogInformation($@"[{nameof(JsonInBase64LeftCommandHandler)}].Handle - 
                    End.| Id={query.Id}");

				return response;
			}
			catch (JsonNotFoundException) { throw; }
			catch (Exception ex)
			{
				_logger.LogError(ex, @$"{nameof(JsonInBase64LeftCommandHandler)} - Error.| Id={query.Id}");
				throw;
			}
		}
	}
}