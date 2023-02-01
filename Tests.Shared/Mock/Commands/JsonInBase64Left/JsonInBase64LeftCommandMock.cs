using CompareJson.Domain.Commands.JsonInBase64Left;

namespace CompareJson.Tests.Shared.Mock.Commands.JsonInBase64Left
{
	public static class JsonInBase64LeftCommandMock
	{
		public static JsonInBase64LeftCommand GetDefaultInstanceLeft() =>
			new JsonInBase64LeftCommand("ewogICAgImJhc2U2NCIgOiAiYWFhYSIKfQ==", 1) { };

		public static JsonInBase64LeftCommand Get64InvalidLeft() =>
			new JsonInBase64LeftCommand("EHU0H011E88EHASÁZZ", 1) { };
	}
}