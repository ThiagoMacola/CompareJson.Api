using System.ComponentModel;

namespace CompareJson.Api.Domain.Enum
{
	public enum Result
	{
		[Description("The data are the same.")]
		Equals = 0,

		[Description("The data are different sizes")]
		DifferentSizes = 1,

		[Description("They are the same size but with differences")]
		Different = 2
	}
}