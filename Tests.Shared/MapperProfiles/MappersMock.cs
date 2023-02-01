using AutoMapper;
using CompareJson.Domain.Commands.JsonInBase64Left;
using CompareJson.Domain.Commands.JsonInBase64Right;
using CompareJson.Domain.Querys.JsonCompare;


namespace CompareJson.Tests.Shared.MapperProfiles
{
	public static class MappersMock
	{
		public static IMapper GetMock()
		{
			var mapperConfigurationExpression = new MapperConfigurationExpression();

			mapperConfigurationExpression.AddProfile<JsonInBase64LeftCommandProfile>();
			mapperConfigurationExpression.AddProfile<JsonInBase64RightCommandProfile>();
			mapperConfigurationExpression.AddProfile<JsonCompareQueryProfile>();

			var mapperConfiguration = new MapperConfiguration(mapperConfigurationExpression);
			mapperConfiguration.AssertConfigurationIsValid();

			return new Mapper(mapperConfiguration);
		}
	}
}
