using System.ComponentModel.DataAnnotations.Schema;

namespace TreinandoPráticasApi.DTO
{
    public class CategoriaDTO
    {
        public int Id { get; set; }
        public string DsNome { get; set; }

        [Column("ds_imagem")]
        public string DsImagem { get; set; }
    }
}
