using AutoMapper;
using CompareJson.Api.Domain.Commands.JsonInBase64Left;
using CompareJson.Api.Domain.Interfaces.Repository.Mongo;
using MediatR;
using System;

namespace CompareJson.Api.Domain.Commands.JsonInBase64Right
{
	public class JsonInBase64RightCommandHandler : IRequestHandler<JsonInBase64RightCommand, JsonInBase64RightCommandResponse>
	{
		private readonly IJsonInBase64RightRepository _jsonInBase64RightRepository;
		private readonly IMapper _mapper;
		private readonly ILogger _logger;

		public JsonInBase64RightCommandHandler
		(
			IJsonInBase64RightRepository jsonInBase64RightRepository,
			IMapper mapper,
			ILoggerFactory loggerFactorty
		)
		{
			_jsonInBase64RightRepository = jsonInBase64RightRepository;
			_mapper = mapper;
			_logger = loggerFactorty.CreateLogger<JsonInBase64RightCommandHandler>();
		}

		public async Task<JsonInBase64RightCommandResponse> Handle(JsonInBase64RightCommand command, CancellationToken cancellationToken)
		{
			try
			{
				_logger.LogInformation($@"[{nameof(JsonInBase64RightCommandHandler)}].Handle - 
                     Start. | JsonInBase64={command.Base64} | Id={command.Id}");

				var jsonInBase64 = _mapper.Map<Entities.JsonInBase64>(command);

				_jsonInBase64RightRepository.Insert(jsonInBase64);

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
