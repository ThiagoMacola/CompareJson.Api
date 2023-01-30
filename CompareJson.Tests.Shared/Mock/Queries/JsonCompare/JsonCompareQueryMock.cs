using CompareJson.Domain.Querys.JsonCompare;

namespace CompareJson.Tests.Shared.Mock.Queries.JsonCompare
{
	public static class JsonCompareQueryMock
	{
		public static JsonCompareQuery GetDefaultInstance() =>
			new JsonCompareQuery(1) { };
	}
}