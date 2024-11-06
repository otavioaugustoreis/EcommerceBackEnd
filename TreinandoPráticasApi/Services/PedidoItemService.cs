using TreinandoPráticasApi.Context;
using TreinandoPráticasApi.Entities;
using TreinandoPráticasApi.Repositories;

namespace TreinandoPráticasApi.Services
{
    public class PedidoItemService 
    {

        protected PedidoItemEntity pedidoItemEntity;
        protected readonly AppDbContext _context;

        public  PedidoItemService( AppDbContext _context)
        {
            this._context = _context;
        }

        public PedidoItemService()
        {
        }

        public PedidoItemEntity AdicionarPedidoItem(ProdutoEntity produtoEntity, PedidoEntity pedidoEntity, int quantidade)
        {
            pedidoItemEntity = new PedidoItemEntity
            {
                produtoEntity = produtoEntity,  
                PedidoEntity = pedidoEntity,    
                Quantidade = quantidade        
            };

            _context._PedidoItemEntities.Add(pedidoItemEntity);
            _context.SaveChanges();

            return pedidoItemEntity;
        }
    }
}
