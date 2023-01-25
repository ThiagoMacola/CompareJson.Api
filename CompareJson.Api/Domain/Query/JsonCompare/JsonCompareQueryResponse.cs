using CompareJson.Api.Domain.Enum;

namespace CompareJson.Api.Domain.Query.JsonCompare
{
	public class JsonCompareQueryResponse
	{
		public int? Key { get; set; }
		public string? Result { get; set; }
		public List<DiffResponse>? ListDiff { get; set; }
		public class DiffResponse
		{
			public char Caracter { get; set; }
		}
	}
}