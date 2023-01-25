using AutoMapper;
using CompareJson.Api.Domain.Interfaces.Repository.Mongo;
using MediatR;

namespace CompareJson.Api.Domain.Commands.JsonInBase64Left
{
	public class JsonInBase64LeftCommandHandler : IRequestHandler<JsonInBase64LeftCommand, JsonInBase64LeftCommandResponse>
	{
		private readonly IJsonInBase64LeftRepository _jsonInBase64LeftRepository;
		private readonly IMapper _mapper;
		private readonly ILogger _logger;

		public JsonInBase64LeftCommandHandler
		(
			IJsonInBase64LeftRepository jsonInBase64LeftRepository,
			IMapper mapper,
			ILoggerFactory loggerFactorty
		)
		{
			_jsonInBase64LeftRepository = jsonInBase64LeftRepository;
			_mapper = mapper;
			_logger = loggerFactorty.CreateLogger<JsonInBase64LeftCommandHandler>();
		}

		public async Task<JsonInBase64LeftCommandResponse> Handle(JsonInBase64LeftCommand command, CancellationToken cancellationToken)
		{
			try
			{
				_logger.LogInformation($@"[{nameof(JsonInBase64LeftCommandHandler)}].Handle - 
                    Start. | JsonInBase64={command.Base64} | Id={command.Id}");

				var jsonInBase64 = _mapper.Map<Entities.JsonInBase64>(command);

				 _jsonInBase64LeftRepository.Insert(jsonInBase64);

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
