using AutoMapper;
using ComparaJson.CrossCutting.Configuration.Helpers;
using CompareJson.CrossCutting.Exceptions;
using CompareJson.Domain.Entities;
using CompareJson.Domain.Interfaces.Repository.InMemory;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CompareJson.Domain.Commands.JsonInBase64Right
{
	public class JsonInBase64RightCommandHandler : IRequestHandler<JsonInBase64RightCommand, JsonInBase64RightCommandResponse>
	{

		private readonly IMapper _mapper;
		private readonly ILogger _logger;
		private readonly IJsonBase64Repository _jsonBase64Repository;
		public JsonInBase64RightCommandHandler
		(

			IMapper mapper,
			ILoggerFactory loggerFactorty,
			IJsonBase64Repository jsonBase64Repository
		)
		{
			_mapper = mapper;
			_logger = loggerFactorty.CreateLogger<JsonInBase64RightCommandHandler>();
			_jsonBase64Repository = jsonBase64Repository;
		}

		public async Task<JsonInBase64RightCommandResponse> Handle(JsonInBase64RightCommand command, CancellationToken cancellationToken)
		{
			try
			{
				_logger.LogInformation($@"[{nameof(JsonInBase64RightCommandHandler)}].Handle - 
                     Start. | JsonInBase64={command.Base64} | Id={command.Id}");

				var jsonInBase64 = _mapper.Map<JsonInBase64>(command);

				if (!jsonInBase64.IsBase64String(jsonInBase64.Base64))
					throw new JsonIsNotBase64Exception();

				await _logger.Measure(async () => await _jsonBase64Repository.AddOrUpdateJsonAsync(jsonInBase64), "AddOrUpdateJsonAsync");

				_logger.LogInformation($@"[{nameof(JsonInBase64RightCommandHandler)}].Handle - 
                     End. | JsonInBase64={command.Base64} | Id={command.Id}");

				return new JsonInBase64RightCommandResponse();
			}
			catch (JsonIsNotBase64Exception) { throw; }
			catch (Exception ex)
			{
				_logger.LogError(ex, @$"{nameof(JsonInBase64RightCommandHandler)} - JsonInBase64={command.Base64} | Id={command.Id}");
				throw;
			}
		}
	}
}
