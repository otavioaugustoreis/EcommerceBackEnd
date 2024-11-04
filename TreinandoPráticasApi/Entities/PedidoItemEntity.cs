using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using TreinandoPráticasApi.Repositories;

namespace TreinandoPráticasApi.Entities
{
    public class PedidoItemEntity : EntityPattern
    {
        [Column("nr_valor")]
        public double  Valor { get; set; }

        [Column("nr_quantidade")]
        public int Quantidade { get; set; }

        [Column("fk_pedido")]
        public int pedidoId { get; set; }

        public PedidoEntity PedidoEntity { get; set; }

        [Column("fk_produto")]
        public int ProdutoId { get; set; }
        public ProdutoEntity produtoEntity { get; set; }

        public PedidoItemEntity() 
        {
        }

        public PedidoItemEntity(int id,double valor, int quantidade, PedidoEntity pedidoEntity, ProdutoEntity produtoEntity)
            : base(id)
        {
            Valor = valor;
            Quantidade = quantidade;
            PedidoEntity = pedidoEntity;
            this.produtoEntity = produtoEntity;
        }
    }
}
