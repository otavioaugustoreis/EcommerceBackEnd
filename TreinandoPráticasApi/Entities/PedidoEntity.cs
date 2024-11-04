using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using TreinandoPráticasApi.Repositories;

namespace TreinandoPráticasApi.Entities
{
    [Table("TB_PEDIDO")]
    public class PedidoEntity : EntityPattern
    {
        [Column("fk_usuario")]
        [Required]
        public int UsuarioId { get; set; }
        public UsuarioEntity usuarioEntity { get; set; }

        public ICollection<PedidoItemEntity> pedidoItems { get; set; }

        public PedidoEntity() 
        { 

        }

        public PedidoEntity(int id, int idUsuario, UsuarioEntity usuarioEntity)
            : base(id)
        {
            UsuarioId = idUsuario;
            this.usuarioEntity = usuarioEntity;
            this.pedidoItems = new List<PedidoItemEntity>();
        }

        public void AdicionarPedidoItem(PedidoItemEntity pedidoItem)
        {
            this.pedidoItems.Add(pedidoItem);
        }
    }
}
