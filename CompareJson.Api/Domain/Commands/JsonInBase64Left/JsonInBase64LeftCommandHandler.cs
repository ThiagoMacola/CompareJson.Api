using AutoMapper;
using CompareJson.Api.CrossCutting.Configuration.Helpers;
using CompareJson.Api.Domain.Entities;
using CompareJson.Api.Domain.Interfaces.Repository.Mongo;
using MediatR;

namespace CompareJson.Api.Domain.Commands.JsonInBase64Left
{
	public class JsonInBase64LeftCommandHandler : IRequestHandler<JsonInBase64LeftCommand, JsonInBase64LeftCommandResponse>
	{
		private readonly IJsonInBase64MongoRepository _jsonInBase64Repository;
		private readonly IMapper _mapper;
		private readonly ILogger _logger;

		public JsonInBase64LeftCommandHandler
		(
			IJsonInBase64MongoRepository jsonInBase64Repository,
			IMapper mapper,
			ILoggerFactory loggerFactorty
		)
		{
			_jsonInBase64Repository = jsonInBase64Repository;
			_mapper = mapper;
			_logger = loggerFactorty.CreateLogger<JsonInBase64LeftCommandHandler>();
		}

		public async Task<JsonInBase64LeftCommandResponse> Handle(JsonInBase64LeftCommand command, CancellationToken cancellationToken)
		{
			try
			{
				_logger.LogInformation($@"[{nameof(JsonInBase64LeftCommandHandler)}].Handle - 
                    Start. | JsonInBase64={command.Base64} | Id={command.Id}");

				var jsonInBase64 = _mapper.Map<JsonInBase64>(command);

				await _logger.Mensure(async () => await _jsonInBase64Repository.InsertAsync(jsonInBase64), "InsertLeftAsync");

				_logger.LogInformation($@"[{nameof(JsonInBase64LeftCommandHandler)}].Handle - 
                    End. | JsonInBase64={command.Base64} | Id={command.Id}");

				return new JsonInBase64LeftCommandResponse();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, @$"{nameof(JsonInBase64LeftCommandHandler)} - JsonInBase64={command.Base64} | Id={command.Id}");
				throw;
			}
		}
	}
}
