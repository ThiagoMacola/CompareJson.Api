namespace CompareJson.Api.CrossCutting.Execeptions
{
	public class StringIsNotBase64Exception : BadHttpRequestException
	{
		public StringIsNotBase64Exception(
			string message = "Provided string is not a base64.",
			int statusCode = 400)
			: base(message, statusCode) { }
	}

}