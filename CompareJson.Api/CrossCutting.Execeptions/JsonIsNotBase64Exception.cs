using CompareJson.Api.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CompareJson.Api.CrossCutting.Execeptions
{
	public class JsonIsNotBase64Exception : Exception, IExceptionFilter
	{
		public void OnException(ExceptionContext context)
		{
			context.ExceptionHandled = true;
			
			var exception = context.Exception;

			bool isSuccesse = false;
			string message = "Base64 is invalid format";
			
			var response = new Response(isSuccesse, message);
			context.Result = new JsonResult(response) { StatusCode = 400 };
		}
	}
}