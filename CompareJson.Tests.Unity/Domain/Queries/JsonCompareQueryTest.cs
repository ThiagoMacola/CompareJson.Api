using CompareJson.Domain.Querys.JsonCompare;
using CompareJson.Tests.Shared.Infrastructure.Repositories.InMemory;
using CompareJson.Tests.Shared.MapperProfiles;
using CompareJson.Tests.Shared.Mock.Queries.JsonCompare;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace CompareJson.Tests.Unity.Domain.Queries
{
	public class JsonCompareQueryTest
	{
		private JsonCompareQueryHandler GetContext() =>
			new JsonCompareQueryHandler(
				MappersMock.GetMock(),
				new Mock<LoggerFactory>().Object,
				new JsonBase64RepositoryMock().SelectAsync()


			);

		[TestCase(Category = "Unity", TestName = "001 - Should call Handle method successfully")]
		public void ShouldCallHandleMethodSuccessfully()
		{
			var command = JsonCompareQueryMock.GetDefaultInstance();

			Assert.DoesNotThrowAsync(async () => await GetContext().Handle(command, CancellationToken.None));
		}

		[TestCase(Category = "Unity", TestName = "002 - Should call Handle method and JsonNotFoundException successfully")]
		public void ShouldCallHandleMethodJsonNotFoundExceptionSuccessfully()
		{
			var command = new JsonCompareQuery(-1);

			Assert.DoesNotThrowAsync(async () => await GetContext().Handle(command, CancellationToken.None));
		}
	}
}
