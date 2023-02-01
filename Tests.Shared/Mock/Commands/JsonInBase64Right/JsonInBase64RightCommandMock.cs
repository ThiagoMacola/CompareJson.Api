using CompareJson.Domain.Commands.JsonInBase64Right;

namespace CompareJson.Tests.Shared.Mock.Commands.JsonInBase64Right
{
	public static class JsonInBase64RightCommandMock
	{
		public static JsonInBase64RightCommand GetDefaultInstanceRight() =>
			new JsonInBase64RightCommand("ewogICAgImJhc2U2NCIgOiAiYWFhYSIKfQ==", 1) { };

		public static JsonInBase64RightCommand Get64InvalidRight() =>
			new JsonInBase64RightCommand("EHU0H011E88EHASÁZZ", 1) { };
	}
}