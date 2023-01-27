﻿using AutoMapper;
using CompareJson.Api.Domain.Entities;
using CompareJson.Api.Domain.Enum;
using EnumsNET;

namespace CompareJson.Api.Domain.Commands.JsonInBase64Left
{
	public class JsonInBase64LeftCommandProfile : Profile
	{
		public JsonInBase64LeftCommandProfile()
		{
			CreateMap<JsonInBase64LeftCommand, JsonInBase64>()
				.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
				.ForMember(dest => dest.Base64, opt => opt.MapFrom(src => src.Base64))
				.ForMember(dest => dest.Position, opt => opt.MapFrom(src => (Position.Left).ToString()));
		}
	}
}