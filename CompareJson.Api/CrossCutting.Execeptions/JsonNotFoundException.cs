namespace CompareJson.Api.CrossCutting.Execeptions
{
	public sealed class JsonNotFoundException : Exception
	{
		public JsonNotFoundException() : base($"O id do json informado não foi necontrado ou na base Right, ou na base Left, ou em ambas.")
		{ }
	}
}