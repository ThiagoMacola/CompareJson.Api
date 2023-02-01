using CompareJson.Tests.Shared.Core;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompareJson.Domain.Interfaces.DomainService;
using CompareJson.Domain.Interfaces.Repository.InMemory;
using CompareJson.Tests.Shared.Mock.Entities;
using NSubstitute;
using CompareJson.Domain.Entities;

namespace CompareJson.Tests.Shared.Mock.DomainService
{
	public class JsonInBase64CompareDomainServiceMock
	{
		private readonly IJsonInBase64CompareDomainService mock = Substitute.For<IJsonInBase64CompareDomainService>();

		public IJsonInBase64CompareDomainService CompareJsonInBase64Async()
		{
			mock.CompareJsonInBase64Async(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<int>()).Returns(new ResultCompareJsonInBase64());

			return mock;
		}

		public IJsonInBase64CompareDomainService ProcessDiffs()
		{
			mock.ProcessDiffsAsync(Arg.Any<string>(), Arg.Any<string>()).Returns(10);

			return mock;
		}
	}
}
