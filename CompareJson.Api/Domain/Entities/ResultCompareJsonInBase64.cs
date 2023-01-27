using CompareJson.Api.Domain.Enum;

namespace CompareJson.Api.Domain.Entities
{
	public class ResultCompareJsonInBase64
	{
		public int Id { get; set; }
		public string Result { get; set; }
		public int Length { get; set; }
	}
}