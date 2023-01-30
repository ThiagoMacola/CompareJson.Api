using CompareJson.Domain.Interfaces.Repository.InMemory;
using CompareJson.Tests.Shared.Core;
using CompareJson.Tests.Shared.Mock.Entities;
using Moq;

namespace CompareJson.Tests.Shared.Infrastructure.Repositories.InMemory
{
	public class JourneyRepositoryMock : BaseMock<IJsonBase64Repository>
	{
		public override Mock<IJsonBase64Repository> GetDefaultInstance()
		{
			SelectAsync();
			AddOrUpdateJsonAsync();
			return Mock;
		}

		private void AddOrUpdateJsonAsync()
		{
			Setup(r => r.AddOrUpdateJsonAsync(JsonInBase64Mock.GetDefaultInstance()), It.IsAny<bool>());
		}

		private void SelectAsync()
		{
			Setup(r => r.SelectAsync(It.IsAny<int>(), It.IsAny<string>()), JsonInBase64Mock.GetDefaultInstance());
		}
	}
}