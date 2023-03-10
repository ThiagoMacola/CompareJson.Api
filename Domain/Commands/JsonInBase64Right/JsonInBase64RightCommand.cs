using MediatR;
using System.Text.Json.Serialization;

namespace CompareJson.Domain.Commands.JsonInBase64Right
{
	public class JsonInBase64RightCommand : IRequest<JsonInBase64RightCommandResponse>
	{
		public JsonInBase64RightCommand(string base64, int id)
		{
			Base64 = base64;
			Id = id;
		}

		public string Base64 { get; set; }
		[JsonIgnore]
		public int Id { get; set; }
	}
}