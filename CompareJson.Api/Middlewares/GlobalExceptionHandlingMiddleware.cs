using CompareJson.CrossCutting.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace CompareJson.Api.Middlewares
{
	public class GlobalExceptionHandlingMiddleware : IMiddleware
	{
		private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;

		public GlobalExceptionHandlingMiddleware(ILogger<GlobalExceptionHandlingMiddleware> logger) =>
		_logger = logger;

		public async Task InvokeAsync(HttpContext context, RequestDelegate next)
		{
			try
			{
				await next(context);
			}
			catch (JsonIsNotBase64Exception e)
			{
				_logger.LogError(e, e.Message);

				context.Response.StatusCode =
					(int)HttpStatusCode.BadRequest;

				ProblemDetails problem = new()
				{
					Status = (int)HttpStatusCode.BadRequest,
					Title = "Json is not base64 exception",
					Detail = "Base64 conversion error, invalid value"

				};

				var options = new JsonSerializerOptions { WriteIndented = true };
				var json = JsonSerializer.Serialize(problem, options);

				context.Response.ContentType = "application/json";

				await context.Response.WriteAsync(json);
			}
			catch (JsonNotFoundException e)
			{
				_logger.LogError(e, e.Message);

				context.Response.StatusCode =
					(int)HttpStatusCode.NotFound;

				ProblemDetails problem = new()
				{
					Status = (int)HttpStatusCode.NotFound,
					Title = "Json not found exception",
					Detail = "There is no comparison for this id,, left and right attachment required"

				};

				var options = new JsonSerializerOptions { WriteIndented = true };
				var json = JsonSerializer.Serialize(problem, options);

				context.Response.ContentType = "application/json";

				await context.Response.WriteAsync(json);
			}
			catch (Exception e)
			{
				_logger.LogError(e, e.Message);

				context.Response.StatusCode =
					(int)HttpStatusCode.InternalServerError;

				ProblemDetails problem = new()
				{
					Status = (int)HttpStatusCode.InternalServerError,
					Type = "Server error",
					Title = "Server error",
					Detail = "An internal server has occurred"
				};

				var options = new JsonSerializerOptions { WriteIndented = true };
				var json = JsonSerializer.Serialize(problem, options);

				context.Response.ContentType = "application/json";

				await context.Response.WriteAsync(json);

			}
		}
	}
}