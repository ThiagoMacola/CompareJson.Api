using Microsoft.AspNetCore.Http.HttpResults;
using System.Net;

namespace CompareJson.Api.CrossCutting.Execeptions
{
	public sealed class JsonNotFoundException : BadHttpRequestException
	{
		public JsonNotFoundException(
			string message = "O id do json informado não foi necontrado ou na base Right, ou na base Left, ou em ambas.",
			int statusCode = 400)
			: base(message, statusCode) {}
	}		
}