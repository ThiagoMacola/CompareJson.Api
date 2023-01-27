using AutoMapper;
using CompareJson.Api.CrossCutting.Configuration.Helpers;
using CompareJson.Api.CrossCutting.Execeptions;
using CompareJson.Api.Domain.Commands.JsonInBase64Left;
using CompareJson.Api.Domain.Entities;
using CompareJson.Api.Domain.Enum;
using CompareJson.Api.Domain.Interfaces.Repository.InMemory;
using EnumsNET;
using MediatR;
using System;

namespace CompareJson.Api.Domain.Query.JsonCompare
{
	public class JsonCompareQueryHandler : IRequestHandler<JsonCompareQuery, JsonCompareQueryResponse>
	{

		private readonly IMapper _mapper;
		private readonly ILogger _logger;
		private readonly IJsonBase64Repository _test;

		public JsonCompareQueryHandler
		(

			IMapper mapper,
			ILoggerFactory loggerFactorty,
			IJsonBase64Repository teste
		)
		{
			_mapper = mapper;
			_logger = loggerFactorty.CreateLogger<JsonCompareQueryHandler>();
			_test = teste;
		}

		public async Task<JsonCompareQueryResponse> Handle(JsonCompareQuery query, CancellationToken cancellationToken)
		{
			try
			{
				_logger.LogInformation($@"[{nameof(JsonInBase64LeftCommandHandler)}].Handle - 
                    Start.| Id={query.Id}");

				var inputLeft = await _logger.Measure(async () => await _test.SelectAsync(query.Id, Position.Left.ToString()), "GetJsonAsyncLeft");

				var inputRight = await _logger.Measure(async () => await _test.SelectAsync(query.Id, Position.Right.ToString()), "GetJsonAsyncRight");

				if (inputLeft == null || inputRight == null)
					throw new JsonNotFoundException();

				var comparedJson = CompareJsonInBase64(inputLeft.Base64, inputRight.Base64, query.Id);
				
				var response = _mapper.Map<JsonCompareQueryResponse>(comparedJson);

				_logger.LogInformation($@"[{nameof(JsonInBase64LeftCommandHandler)}].Handle - 
                    End.| Id={query.Id}");

				return response;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, @$"{nameof(JsonInBase64LeftCommandHandler)} - Error.| Id={query.Id}");
				throw;
			}
		}
		private ResultCompareJsonInBase64 CompareJsonInBase64(string inputLeft, string inputRight, int id)
		{
			var response = new ResultCompareJsonInBase64();

			response.Id = id;

			if (inputLeft.Equals(inputRight))
			{
				response.Result = Result.Equals.AsString(EnumFormat.Description);
				return response;
			}
			if (inputLeft.Length != inputRight.Length)
			{
				response.Result = Result.DifferentSizes.AsString(EnumFormat.Description);
				return response;
			}

			response.Result = Result.Different.AsString(EnumFormat.Description);
			response.Length = ProcessDiffs(inputLeft, inputRight);
			return response;

		}
		private int ProcessDiffs(string inputLeft, string inputRight)
		{
			var leftArray = Convert.FromBase64String(inputLeft);
			var rightArray = Convert.FromBase64String(inputRight);

			var offsetList = new List<int>();

			for (int i = 1; i < leftArray.Length; i++)
			{
				if (leftArray[i] != rightArray[i])
				{
					offsetList.Add(i);
				}
			}
			return offsetList.Count;
		}
	}
}