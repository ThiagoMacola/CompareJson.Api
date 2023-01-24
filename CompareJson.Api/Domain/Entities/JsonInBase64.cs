namespace CompareJson.Api.Domain.Entities
{
    public class JsonInBase64
    {
        public JsonInBase64(string base64, int id)
        {
            Base64 = base64;
            Id = id;
        }

        public string Base64 { get; set; }
        public int Id { get; set; }
    }
}
