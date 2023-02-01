using System.ComponentModel;

namespace CompareJson.Domain.Enum
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