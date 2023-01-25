namespace CompareJson.Api.Domain.Entities
{
    public class Diff
    {
        public Diff(char caracter)
        {
            Caracter = caracter;
        }

        public char Caracter { get; set; }
    }
}