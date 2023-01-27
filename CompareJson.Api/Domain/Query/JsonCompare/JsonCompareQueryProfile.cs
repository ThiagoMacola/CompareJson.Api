using AutoMapper;
using CompareJson.Api.Domain.Commands.JsonInBase64Right;
using CompareJson.Api.Domain.Entities;
using CompareJson.Api.Domain.Enum;
using EnumsNET;
using static CompareJson.Api.Domain.Query.JsonCompare.JsonCompareQueryResponse;

namespace CompareJson.Api.Domain.Query.JsonCompare
{
    public class JsonCompareQueryProfile : Profile
	{
		public JsonCompareQueryProfile()
		{
			CreateMap<ResultCompareJsonInBase64, JsonCompareQueryResponse>()
			   .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
			   .ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.Result.ToString()))
			   .ForMember(dest => dest.Length, opt => opt.MapFrom(src => src.Length));
		}
	}
}