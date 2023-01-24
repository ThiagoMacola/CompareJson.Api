using MediatR;

namespace CompareJson.Api.Domain.Query.JsonCompare
{
	public class JsonCompareQuery : IRequest<JsonCompareQueryResponse>
	{
		public JsonCompareQuery(int id)
		{
			Id = id;
		}

		public int Id { get; set; }
	}
}