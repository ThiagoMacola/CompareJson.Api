using CompareJson.Domain.Entities;
using CompareJson.Domain.Enum;

namespace CompareJson.Tests.Shared.Mock.Entities
{
	public static class JsonInBase64Mock
	{
		public static JsonInBase64 GetDefaultInstanceLeft() =>
			new JsonInBase64()
			{
				Id = 1,
				Base64 = "ewogICAgImJhc2U2NCIgOiAiYWFhYSIKfQ==",
				Position = Position.Left.ToString()
			};

		public static JsonInBase64 GetDefaultInstanceRight() =>
			new JsonInBase64()
			{
				Id = 1,
				Base64 = "ewogICAgImJhc2U2NCIgOiAiYWFhYSIKfQ==",
				Position = Position.Right.ToString()
			};
	}
}