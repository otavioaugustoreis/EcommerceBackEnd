using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TreinandoPráticasApi.Repositories;

namespace TreinandoPráticasApi.Entities
{
    [Table("TB_CATEGORIA")]
    public class CategoriaEntity : EntityPattern
    {
        public CategoriaEntity() { }

        public CategoriaEntity(int id, string dsNome, string dsImagem)
            : base(id)
        {
            DsNome = dsNome;
            DsImagem = dsImagem;
        }

        public void AdicionarProduto(ProdutoEntity produto)
        {
            this.produtoEntity.Add(produto);
        }

        [Column("ds_nome")]
        [Required]
        [StringLength(80)]
        public string  DsNome { get; set; }

        [Column("ds_imagem")]
        public string  DsImagem { get; set; }

        public  ICollection<ProdutoEntity> produtoEntity { get; set; }  = new List<ProdutoEntity>();
    }
}
