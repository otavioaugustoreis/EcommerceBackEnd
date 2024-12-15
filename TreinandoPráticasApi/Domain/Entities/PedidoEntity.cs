using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using TreinandoPráticasApi.Repositories;

namespace TreinandoPráticasApi.Domain.Entities
{
    [Table("TB_PEDIDO")]
    public class PedidoEntity : EntityPattern
    {
        [Column("fk_usuario")]
        [Required]
        public int UsuarioId { get; set; }
        public UsuarioEntity usuarioEntity { get; set; }

        public List<PedidoItemEntity> pedidoItems { get; set; }

        public PedidoEntity()
        {

        }

        public PedidoEntity(int id, int idUsuario, UsuarioEntity usuarioEntity)
            : base(id)
        {
            UsuarioId = idUsuario;
            this.usuarioEntity = usuarioEntity;
            pedidoItems = new List<PedidoItemEntity>();
        }

        public void AdicionarPedidoItem(PedidoItemEntity pedidoItem)
        {
            pedidoItems.Add(pedidoItem);
        }
    }
}
