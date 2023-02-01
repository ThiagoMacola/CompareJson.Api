using CompareJson.Domain.DomainService;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Moq;
using NUnit.Framework;

namespace CompareJson.Tests.Unity.Domain.DomainService
{

	public class JsonInBase64CompareDomainServiceTests
	{
		private JsonInBase64CompareDomainService GetContext() => new(new Mock<LoggerFactory>().Object);

		[TestCase(Category = "Unity", TestName = "001 - Should CompareJsonInBase64Async Result is Equal - Success")]
		public void Should_CompareJsonInBase64Async_Success_Result_Equals()
		{
			var inputLeft = "ewogICAgImJhc2U2NCI6ICJhYWEiCn0=";
			var inputRight = "ewogICAgImJhc2U2NCI6ICJhYWEiCn0=";
			var id = 1;

			var service = GetContext().CompareJsonInBase64Async(inputLeft, inputRight, id);

			service.Result.Result.Should().Be("The data are the same.");
		}


		[TestCase(Category = "Unity", TestName = "002 - Should CompareJsonInBase64Async Result is DifferentSizes - Success")]
		public void Should_CompareJsonInBase64Async_Success_Result_DifferentSizes()
		{
			var inputLeft = "ewogICAgImJhc2U2NCI6ICJhYWEiCn0=";
			var inputRight = "ewogICAgImJhc2U2NCI6ICJhYWFiYiIKfQ==";
			var id = 1;

			var service = GetContext().CompareJsonInBase64Async(inputLeft, inputRight, id);

			service.Result.Result.Should().Be("The data are different sizes");
		}

		[TestCase(Category = "Unity", TestName = "003 - Should CompareJsonInBase64Async Result is Different - Success")]
		public void Should_CompareJsonInBase64Async_Success_Result_Different()
		{
			var inputLeft = "ewogICAgImJhc2U2NCI6ICJhYWEiCn0=";
			var inputRight = "ewogICAgImJhc2U2NCI6ICJiYmIiCn0=";
			var id = 1;

			var service = GetContext().CompareJsonInBase64Async(inputLeft, inputRight, id);
			service.Result.Result.Should().Be("They are the same size but with differences");
		}

		[TestCase(Category = "Unity", TestName = "004 - Should ProcessDiffsAsync - Success")]
		public void Should_ProcessDiffsAsync_Success()
		{
			var inputLeft = "ewogICAgImJhc2U2NCI6ICJhYWEiCn0=";
			var inputRight = "ewogICAgImJhc2U2NCI6ICJiYmIiCn0=";

			var service = GetContext().ProcessDiffsAsync(inputLeft, inputRight);

			service.Result.Should().Be(3);
		}
	}
}
