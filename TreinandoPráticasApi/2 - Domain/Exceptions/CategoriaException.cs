namespace TreinandoPráticasApi._2___Domain.Exceptions
{
    public class CategoriaException : Exception
    {
        private const string  MENSAGEM_PADRAO = "Categoria não encontrada";
        public CategoriaException(string? message = MENSAGEM_PADRAO) : base(message)
        {
        }
    }
}
