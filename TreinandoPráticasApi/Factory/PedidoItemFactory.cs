using Microsoft.CodeAnalysis.CSharp.Syntax;
using TreinandoPráticasApi.Entities;

namespace TreinandoPráticasApi.Factory
{
    public record PedidoItemFactory
    {
        public PedidoItemEntity InstanciarPedidoItem(int id, double valor,int quantidade, PedidoEntity pedidoEntity, ProdutoEntity produtoEntity) 
            => new PedidoItemEntity(id, valor, quantidade, pedidoEntity, produtoEntity);
    }
}