using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TreinandoPráticasApi.Repositories;

namespace TreinandoPráticasApi.Entities
{

    [Table("TB_PRODUTO")]
    public class ProdutoEntity : EntityPattern
    {
        public ProdutoEntity() { }

        public ProdutoEntity(string dsNome, int nrQuantidade)
        {
            DsNome = dsNome;
            NrQuantidade = nrQuantidade;
        }

        [Column("ds_nome")]
        [Required]
        public string DsNome  { get; set; }

        [Column("nr_quantidade")]
        [Required]
        public int NrQuantidade { get; set; }

        [Column("fk_categoria")] 
        public int Fkcategoria { get; set; }
        public CategoriaEntity categoriaEntity { get; set; }


        [Column("fk_usuario")]
        public int FkUsuario { get; set; }
        public UsuarioEntity usuarioEntity { get; set; }
    }
}
