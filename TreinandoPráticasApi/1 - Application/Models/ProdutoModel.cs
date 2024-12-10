using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TreinandoPráticasApi._1___Application.Models
{
    public class ProdutoModel
    {
        public int Id { get; set; }

        [Column("ds_nome")]
        [Required]
        public string DsNome { get; set; }

        [Column("nr_quantidade")]
        [Required]
        public int NrQuantidade { get; set; }

        [Column("fk_categoria")]
        public int Fkcategoria { get; set; }
    }
}
