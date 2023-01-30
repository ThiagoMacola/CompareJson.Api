using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompareJson.Domain.Entities;
using CompareJson.Domain.Enum;

namespace CompareJson.Tests.Shared.Mock.Entities
{
	public static class JsonInBase64Mock
	{
		public static JsonInBase64 GetDefaultInstance() =>
			new JsonInBase64()
			{
				Id = 1,
				Base64 = "ewogICAgImJhc2U2NCIgOiAiYWFhYSIKfQ==",
				Position = Position.Left.ToString()
			};
	}
}