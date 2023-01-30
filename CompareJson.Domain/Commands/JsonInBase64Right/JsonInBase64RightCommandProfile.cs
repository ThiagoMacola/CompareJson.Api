using AutoMapper;
using CompareJson.Domain.Entities;
using CompareJson.Domain.Enum;

namespace CompareJson.Domain.Commands.JsonInBase64Right
{
	public class JsonInBase64RightCommandProfile : Profile
	{
		public JsonInBase64RightCommandProfile()
		{
			CreateMap<JsonInBase64RightCommand, JsonInBase64>()
				.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
				.ForMember(dest => dest.Base64, opt => opt.MapFrom(src => src.Base64))
				.ForMember(dest => dest.Position, opt => opt.MapFrom(src => (Position.Right).ToString()));
		}
	}
}