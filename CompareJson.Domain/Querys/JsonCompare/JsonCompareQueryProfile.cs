using AutoMapper;
using CompareJson.Domain.Entities;

namespace CompareJson.Domain.Querys.JsonCompare
{
	public class JsonCompareQueryProfile : Profile
	{
		public JsonCompareQueryProfile()
		{
			CreateMap<ResultCompareJsonInBase64, JsonCompareQueryResponse>()
			   .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
			   .ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.Result!.ToString()))
			   .ForMember(dest => dest.Length, opt => opt.MapFrom(src => src.Length));
		}
	}
}