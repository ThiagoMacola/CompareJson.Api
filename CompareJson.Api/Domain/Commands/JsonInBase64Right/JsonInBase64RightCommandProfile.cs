using AutoMapper;

namespace CompareJson.Api.Domain.Commands.JsonInBase64Right
{
    public class JsonInBase64RightCommandProfile : Profile
    {
        public JsonInBase64RightCommandProfile()
        {
            CreateMap<JsonInBase64RightCommand, Entities.JsonInBase64>();
        }
    }
}
