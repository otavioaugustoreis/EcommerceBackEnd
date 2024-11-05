using NuGet.Protocol;
using System.Collections.Generic;
using TreinandoPráticasApi.Context;
using TreinandoPráticasApi.Entities;
using TreinandoPráticasApi.Repositories;

namespace TreinandoPráticasApi.Services
{

    public class PedidoService : Repository<PedidoEntity>, IPedido
    {

        private readonly PedidoItemService _itemService;
        private readonly ProdutoService produtoService;

        public PedidoService(AppDbContext context) : base(context)
        {
        }

        public void AdicionarPedido(int idPedido,int ProdutoId, int quantidade, int doubleValor)
        {
            ProdutoEntity p1 = produtoService.GetId(p => p.Id == idPedido);
            PedidoEntity pe1 = GetId(p => p.Id == ProdutoId);

            if(p1 is null || pe1 is null)
            {
                 throw new Exception("Produto não encontrado");
            }
            PedidoItemEntity pedidoItem = _itemService.AdicionarPedidoItem(p1, pe1, quantidade);
            pe1.pedidoItems.Add(pedidoItem);
            p1.pedidoItens.Add(pedidoItem);
        }

        public List<ProdutoEntity> ConsultarProdutos(int idPedido)
        {
            PedidoEntity pe1 = GetId(p => p.Id == idPedido);

            List <ProdutoEntity> list = new List<ProdutoEntity>();

            foreach (var produtos in pe1.pedidoItems.ToList())
            {
                list.Add(produtos.produtoEntity);
            }

            return list;
        }
    }
}
