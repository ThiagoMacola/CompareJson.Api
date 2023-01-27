namespace CompareJson.Api.Dto
{
	public class Response
	{
		public Response(bool isSuccessed, string message)
		{
			IsSuccessed = isSuccessed;
			Message = message;
		}

		public bool IsSuccessed { get; set; }
		public string Message { get; set; }
	}
}