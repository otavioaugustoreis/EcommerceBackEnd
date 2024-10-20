using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
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

        public UsuarioEntity(string dsNome, string dsCPF, string dsEmail, int id) : base(id, DateTime.Now)
        {
            DsNome = dsNome;
            DsCPF = dsCPF;
            DsEmail = dsEmail;
        }
    }
}
