using MediatR;

namespace CompareJson.Domain.Commands.JsonInBase64Left
{
	public class JsonInBase64LeftCommand : IRequest<JsonInBase64LeftCommandResponse>
	{
		public JsonInBase64LeftCommand(string base64, int id)
		{
			Base64 = base64;
			Id = id;
		}

		public string Base64 { get; set; }
		public int Id { get; set; }
	}
}