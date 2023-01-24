using AutoMapper;

namespace CompareJson.Api.Domain.Commands.JsonInBase64Left
{
    public class JsonInBase64LeftCommandProfile : Profile
    {
        public JsonInBase64LeftCommandProfile()
        {
            CreateMap<JsonInBase64LeftCommand, Entities.JsonInBase64>();
        }
    }
}
