using Moq;
using System.Linq.Expressions;

namespace CompareJson.Tests.Shared.Core
{
	public abstract class BaseMock<T> where T : class
	{
		public Mock<T> Mock { get; set; }

		protected BaseMock()
		{
			Mock = new Mock<T>();
		}

		public void Setup<TResult>(Expression<Func<T, TResult>> expression, TResult objectReturn)
		{
			Mock.Setup(expression).Returns(objectReturn);
		}

		public void Setup<TResult>(Expression<Func<T, Task<TResult>>> expression, TResult objectReturn)
		{
			Mock.Setup(expression).ReturnsAsync(objectReturn);
		}

		public abstract Mock<T> GetDefaultInstance();
	}
}
