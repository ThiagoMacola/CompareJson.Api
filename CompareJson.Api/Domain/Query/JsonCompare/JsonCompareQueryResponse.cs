using CompareJson.Api.Domain.Enum;

namespace CompareJson.Api.Domain.Query.JsonCompare
{
	public class JsonCompareQueryResponse
	{
		public int Id { get; set; }
		public string Message { get; set; }
		public int? Length { get; set; }	
	}
}