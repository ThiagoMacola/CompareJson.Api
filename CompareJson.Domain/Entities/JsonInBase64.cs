namespace CompareJson.Domain.Entities
{
	public class JsonInBase64
	{
		public int Id { get; set; }
		public string Base64 { get; set; }
		public string Position { get; set; }

		public bool IsBase64String(string base64)
		{
			Span<byte> buffer = new Span<byte>(new byte[base64.Length]);
			return Convert.TryFromBase64String(base64, buffer, out int bytesParsed);
		}
	}
}