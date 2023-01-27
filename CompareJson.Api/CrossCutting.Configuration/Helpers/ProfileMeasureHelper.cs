using System.Diagnostics;

namespace CompareJson.Api.CrossCutting.Configuration.Helpers
{
	public static class ProfileMeasureHelper
	{
		public static async Task<TResult> Measure<TResult>(this ILogger logger, Func<Task<TResult>> func, string messageLog)
		{
			logger.LogInformation($"Iniciou: {messageLog}");

			var stp = Stopwatch.StartNew();
			var result = await func();
			stp.Stop();

			logger.LogInformation($"Fim: {messageLog} | Durou=({stp.Elapsed.TotalMilliseconds}ms)");

			return result;
		}

		public static async Task Mensure(this ILogger logger, Func<Task> func, string messageLog)
		{
			logger.LogInformation($"Iniciou: {messageLog}");

			var stp = Stopwatch.StartNew();
			await func();
			stp.Stop();

			logger.LogInformation($"Fim: {messageLog} | Durou=({stp.Elapsed.TotalMilliseconds}ms)");
		}
	}
}