using TreinandoPráticasApi.Entities;

namespace TreinandoPráticasApi.Repositories
{
    public interface IProduto : IRepository<ProdutoEntity>
    {
        public IEnumerable<ProdutoEntity> ProdutoPorCategoria(int id);
    }
}
