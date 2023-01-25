using AutoMapper;
using CompareJson.Api.Domain.Entities;
using static CompareJson.Api.Domain.Query.JsonCompare.JsonCompareQueryResponse;

namespace CompareJson.Api.Domain.Query.JsonCompare
{
    public class JsonCompareQueryProfile : Profile
	{
		public JsonCompareQueryProfile()
		{
			CreateMap<Diff, DiffResponse>();
		}
	}
}