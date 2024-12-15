using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Reflection;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using TreinandoPráticasApi.Repositories;

namespace TreinandoPráticasApi.Domain.Entities
{
    [Table("TB_USUARIO")]
    public class UsuarioEntity : EntityPattern
    {
        [Column("ds_nome")]
        [Required]
        public string DsNome { get; set; }

        [Column("ds_cpf")]
        [Required]
        public string DsCPF { get; set; }

        [Column("nr_idade")]
        [Required]
        public int NrIdade { get; set; }

        [Column("ds_email")]
        [Required]
        public string DsEmail { get; set; }

        public UsuarioEntity()
        {
        }
        public UsuarioEntity(string dsNome, string dsCPF, string dsEmail, int id, int nrIdade)
            : base(id)
        {
            DsNome = dsNome;
            DsCPF = dsCPF;
            DsEmail = dsEmail;
            NrIdade = nrIdade;
            pedidoEntities = new List<PedidoEntity>();
        }

        private void AdicionarPedidos(PedidoEntity produto)
        {
            pedidoEntities.Add(produto);
        }

        [Column("fk_pedido")]
        public int PedidoId { get; set; }

        [JsonIgnore]
        public ICollection<PedidoEntity> pedidoEntities { get; set; }

    }
}
