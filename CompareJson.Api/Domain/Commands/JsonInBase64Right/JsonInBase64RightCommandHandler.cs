using AutoMapper;
using CompareJson.Api.CrossCutting.Configuration.Helpers;
using CompareJson.Api.Domain.Entities;
using CompareJson.Api.Domain.Interfaces.Repository.Mongo;
using MediatR;

namespace CompareJson.Api.Domain.Commands.JsonInBase64Right
{
	public class JsonInBase64RightCommandHandler : IRequestHandler<JsonInBase64RightCommand, JsonInBase64RightCommandResponse>
	{
		private readonly IJsonInBase64MongoRepository _jsonInBase64Repository;
		private readonly IMapper _mapper;
		private readonly ILogger _logger;

		public JsonInBase64RightCommandHandler
		(
			IJsonInBase64MongoRepository jsonInBasRightRepository,
			IMapper mapper,
			ILoggerFactory loggerFactorty
		)
		{
			_jsonInBase64Repository = jsonInBasRightRepository;
			_mapper = mapper;
			_logger = loggerFactorty.CreateLogger<JsonInBase64RightCommandHandler>();
		}

		public async Task<JsonInBase64RightCommandResponse> Handle(JsonInBase64RightCommand command, CancellationToken cancellationToken)
		{
			try
			{
				_logger.LogInformation($@"[{nameof(JsonInBase64RightCommandHandler)}].Handle - 
                     Start. | JsonInBase64={command.Base64} | Id={command.Id}");

				var jsonInBase64 = _mapper.Map<JsonInBase64>(command);

				await _logger.Mensure(async () => await _jsonInBase64Repository.InsertAsync(jsonInBase64), "InsertRightAsync");

				_logger.LogInformation($@"[{nameof(JsonInBase64RightCommandHandler)}].Handle - 
                     End. | JsonInBase64={command.Base64} | Id={command.Id}");

				return new JsonInBase64RightCommandResponse();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, @$"{nameof(JsonInBase64RightCommandHandler)} - JsonInBase64={command.Base64} | Id={command.Id}");
				throw;
			}
		}
	}
}
