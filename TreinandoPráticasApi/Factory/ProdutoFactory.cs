using Microsoft.CodeAnalysis.CSharp.Syntax;
using TreinandoPráticasApi.Services;

namespace TreinandoPráticasApi.Factory
{
    public class ProdutoFactory
    {
        public static void IProduto() => new ProdutoService(); 
    }
}
