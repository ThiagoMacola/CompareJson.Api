using CompareJson.Domain.Interfaces.Repository.InMemory;
using CompareJson.Tests.Shared.Mock.Entities;
using NSubstitute;

namespace CompareJson.Tests.Shared.Infrastructure.Repositories.InMemory
{
	public class JsonBase64RepositoryMock
	{
		private readonly IJsonBase64Repository mock = Substitute.For<IJsonBase64Repository>();

		public IJsonBase64Repository AddOrUpdateJsonAsync()
		{
			mock.AddOrUpdateJsonAsync((JsonInBase64Mock.GetDefaultInstanceLeft()));

			return mock;
		}

		public IJsonBase64Repository SelectAsync()
		{
			mock.SelectAsync(Arg.Any<int>(), Arg.Any<string>()).Returns(JsonInBase64Mock.GetDefaultInstanceLeft());
			mock.SelectAsync(Arg.Any<int>(), Arg.Any<string>()).Returns(JsonInBase64Mock.GetDefaultInstanceRight());

			return mock;
		}
	}
}