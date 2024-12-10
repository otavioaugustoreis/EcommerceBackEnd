using System.ComponentModel.DataAnnotations.Schema;

namespace TreinandoPráticasApi._1___Application.Models
{
    public class CategoriaModel
    {
        public int Id { get; set; }
        public string DsNome { get; set; }

        [Column("ds_imagem")]
        public string DsImagem { get; set; }
    }
}
