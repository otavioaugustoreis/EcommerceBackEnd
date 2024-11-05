using TreinandoPráticasApi.Context;
using TreinandoPráticasApi.Entities;
using TreinandoPráticasApi.Factory;
using TreinandoPráticasApi.Repositories;

namespace TreinandoPráticasApi.Services
{
    public class PedidoService : Repository<PedidoEntity>, IPedido
    {

        private readonly PedidoItemService _itemService;

        public PedidoService(AppDbContext context) : base(context)
        {
        }

        public void AdicionarProduto(ProdutoEntity produto)
        {
            _itemService.AdicionarProduto(produto);
        }

        public void ConsultarProdutos()
        {
            throw new NotImplementedException();
        }
    }
}
