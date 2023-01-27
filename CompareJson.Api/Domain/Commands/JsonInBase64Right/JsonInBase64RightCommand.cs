using MediatR;
using Newtonsoft.Json;

namespace CompareJson.Api.Domain.Commands.JsonInBase64Right
{
    public class JsonInBase64RightCommand : IRequest<JsonInBase64RightCommandResponse>
    {
		public JsonInBase64RightCommand(string base64, int id)
		{
			Base64 = base64;
			Id = id;
		}

		public string Base64 { get; set; }
		public int Id { get; set; }
	}
}