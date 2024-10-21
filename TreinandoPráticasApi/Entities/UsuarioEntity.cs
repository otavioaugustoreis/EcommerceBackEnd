using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Reflection;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using TreinandoPráticasApi.Repositories;

namespace TreinandoPráticasApi.Entities
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
        public UsuarioEntity(string dsNome, string dsCPF, string dsEmail, int id, int nrIdade) : base(id, DateTime.Now)
        {
            DsNome = dsNome;
            DsCPF = dsCPF;
            DsEmail = dsEmail;
            NrIdade = nrIdade;
            produtoEntity = new List<ProdutoEntity>();
        }

        private void AdicionarProduto(ProdutoEntity produto) 
        {
            this.produtoEntity.Add(produto);
        }


        [JsonIgnore]
        public ICollection<ProdutoEntity> produtoEntity { get; set; }

    }
}
