using TreinandoPráticasApi._1___Application.Pagination;
using TreinandoPráticasApi.Entities;

namespace TreinandoPráticasApi.Repositories
{
    public interface ICategoria : IRepository<CategoriaEntity>
    {
        PagedList<CategoriaEntity> GetCategorias(CategoriaParameters categoriaParameters);
    }
}
