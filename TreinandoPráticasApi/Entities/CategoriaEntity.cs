using System.ComponentModel.DataAnnotations.Schema;
using TreinandoPráticasApi.Repositories;

namespace TreinandoPráticasApi.Entities
{
    public class CategoriaEntity : EntityPattern
    {
        public CategoriaEntity() { }

        public CategoriaEntity(int id, string dsNome, string dsImagem)
            : base(id)
        {
            DsNome = dsNome;
            DsImagem = dsImagem;
            produtoEntity = new List<ProdutoEntity>();
        }

        public void AdicionarProduto(ProdutoEntity produto)
        {
            this.produtoEntity.Add(produto);
        }

        public string  DsNome { get; set; }

        [Column("ds_imagem")]
        public string  DsImagem { get; set; }

        public  ICollection<ProdutoEntity> produtoEntity { get; set; }
    }
}
