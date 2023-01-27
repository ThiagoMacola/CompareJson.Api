using System.ComponentModel;

namespace CompareJson.Api.Domain.Enum
{
	public enum Result
	{
		[Description("Equals")]
		Equals = 0,

		[Description("DifferentSizes")]
		DifferentSizes = 1,

		[Description("Different")]
		Different = 2
	}
}