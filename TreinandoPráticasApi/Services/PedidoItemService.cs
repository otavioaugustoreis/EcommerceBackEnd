using TreinandoPráticasApi.Context;
using TreinandoPráticasApi.Entities;
using TreinandoPráticasApi.Repositories;

namespace TreinandoPráticasApi.Services
{
    public class PedidoItemService 
    {

        protected PedidoItemEntity pedidoItemEntity;
        protected readonly AppDbContext _context;

        public  PedidoItemService(PedidoItemEntity pedidoItemEntity)
        {
            this.pedidoItemEntity = pedidoItemEntity;
        }

        public void AdicionarProduto(ProdutoEntity produtoEntity)
        { 
          pedidoItemEntity.produtoEntity = produtoEntity;
        }
         
    }
}
