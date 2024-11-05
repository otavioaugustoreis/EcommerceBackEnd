using NuGet.DependencyResolver;
using TreinandoPráticasApi.Entities;

namespace TreinandoPráticasApi.Repositories
{
    public interface IPedido : IRepository<PedidoEntity>
    {
        void AdicionarPedido(int idPedido, int ProdutoId, int quantidade, int doubleValor);
        List<ProdutoEntity> ConsultarProdutos(int idPedido);
    }
}
