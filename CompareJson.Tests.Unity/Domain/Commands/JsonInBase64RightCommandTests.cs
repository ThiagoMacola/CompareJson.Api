using CompareJson.CrossCutting.Exceptions;
using CompareJson.Domain.Commands.JsonInBase64Right;
using CompareJson.Domain.Interfaces.Repository.InMemory;
using CompareJson.Tests.Shared.MapperProfiles;
using CompareJson.Tests.Shared.Mock.Commands.JsonInBase64Right;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace CompareJson.Tests.Unity.Domain.Commands
{
	public class JsonInBase64RightCommandTests
	{
		private JsonInBase64RightCommandHandler GetContext(
			IJsonBase64Repository jsonBase64Repository = null!)
		{
			return new JsonInBase64RightCommandHandler(
				MappersMock.GetMock(),
				new Mock<LoggerFactory>().Object,
				jsonBase64Repository ?? new Mock<IJsonBase64Repository>().Object
			);
		}

		[TestCase(Category = "Unity", TestName = "001 - Should call Handle method successfully")]
		public void ShouldCallHandleMethodSuccessfully()
		{
			var command = JsonInBase64RightCommandMock.GetDefaultInstanceRight();

			var context = GetContext(jsonBase64Repository: new Mock<IJsonBase64Repository>().Object);

			Assert.DoesNotThrowAsync(async () => await context.Handle(command, CancellationToken.None));
		}

		[TestCase(Category = "Unity", TestName = "002 - Should call Handle method and JsonIsNotBase64Exception successfully")]
		public void ShouldCallHandlerJsonIsNotBase64Exception()
		{
			var command = JsonInBase64RightCommandMock.Get64InvalidRight();

			var context = GetContext(jsonBase64Repository: new Mock<IJsonBase64Repository>().Object);

			Assert.ThrowsAsync<JsonIsNotBase64Exception>(() => context.Handle(command, default));
		}
	}
}