using AutoMapper;
using CompareJson.Api.CrossCutting.Execeptions;
using CompareJson.Api.Domain.Commands.JsonInBase64Left;
using CompareJson.Api.Domain.Entities;
using CompareJson.Api.Domain.Enum;
using CompareJson.Api.Domain.Interfaces.Repository.Mongo;
using MediatR;
using static CompareJson.Api.Domain.Query.JsonCompare.JsonCompareQueryResponse;

namespace CompareJson.Api.Domain.Query.JsonCompare
{
	public class JsonCompareQueryHandler : IRequestHandler<JsonCompareQuery, JsonCompareQueryResponse>
	{
		private readonly IJsonInBase64LeftRepository _jsonInBase64LeftRepository;
		private readonly IJsonInBase64RightRepository _jsonInBase64RightRepository;
		private readonly IMapper _mapper;
		private readonly ILogger _logger;

		public JsonCompareQueryHandler
		(
			IJsonInBase64LeftRepository jsonInBase64LeftRepository,
			IJsonInBase64RightRepository jsonInBase64RightRepository,
			IMapper mapper,
			ILoggerFactory loggerFactorty
		)
		{
			_jsonInBase64LeftRepository = jsonInBase64LeftRepository;
			_jsonInBase64RightRepository = jsonInBase64RightRepository;
			_mapper = mapper;
			_logger = loggerFactorty.CreateLogger<JsonCompareQueryHandler>();
		}

		public async Task<JsonCompareQueryResponse> Handle(JsonCompareQuery query, CancellationToken cancellationToken)
		{
			try
			{
				_logger.LogInformation($@"[{nameof(JsonInBase64LeftCommandHandler)}].Handle - 
                    Start.| Id={query.Id}");

				var inputLeft = _jsonInBase64LeftRepository.GetJson(query.Id);
				var inputRight = _jsonInBase64RightRepository.GetJson(query.Id);

				if (inputLeft == null || inputRight == null)
					throw new JsonNotFoundException();

				var response = CompareJsonInBase64(query, inputLeft, inputRight);

				_logger.LogInformation($@"[{nameof(JsonInBase64LeftCommandHandler)}].Handle - 
                    End.| Id={query.Id}");

				return response;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, @$"{nameof(JsonInBase64LeftCommandHandler)} - Erro.| Id={query.Id}");
				throw;
			}
		}

		private JsonCompareQueryResponse CompareJsonInBase64(JsonCompareQuery query, JsonInBase64 inputLeft, JsonInBase64 inputRight)
		{
			var response = new JsonCompareQueryResponse();

			response.Key = query.Id;

			if (inputLeft.Base64.Equals(inputRight.Base64))
			{
				response.Result = ResultEnum.Equals.ToString();
				return response;
			}
			else if (inputLeft.Base64.Length != inputRight.Base64.Length)
			{
				response.Result = ResultEnum.DifferentSizes.ToString();
				return response;
			}
			else
			{
				response.Result = ResultEnum.Different.ToString();
				var listDiff = _mapper.Map<List<DiffResponse>>(ProcessDiffs(inputLeft, inputRight));
				response.ListDiff = listDiff;
				return response;
			}
		}

		private List<Diff> ProcessDiffs(JsonInBase64 inputLeft, JsonInBase64 inputRight)
		{
			var diffList = new List<Diff>();

			for (int i = 1; i < inputLeft.Base64.Length; i++)
			{
				if (inputLeft.Base64[i] != inputRight.Base64[i])
				{
					diffList.Add(new Diff(inputLeft.Base64[i]));
				}
			}
			return diffList;
		}
	}
}