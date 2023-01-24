using System.ComponentModel;

namespace CompareJson.Api.Domain.Enum
{
	public enum ResultEnum
	{
		[Description("Equals")]
		Equals = 0,

		[Description("DifferentSizes")]
		DifferentSizes = 1,

		[Description("Different")]
		Different = 2
	}
}