using MediatR;

namespace CompareJson.Domain.Querys.JsonCompare
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