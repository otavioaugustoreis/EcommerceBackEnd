using NuGet.DependencyResolver;
using TreinandoPráticasApi.Entities;

namespace TreinandoPráticasApi.Repositories
{
    public interface IPedido : IRepository<PedidoEntity>
    {
        void AdicionarProduto();
        void ConsultarProdutos();
    }
}
