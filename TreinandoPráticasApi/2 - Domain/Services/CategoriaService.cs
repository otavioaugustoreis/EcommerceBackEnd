using Pomelo.EntityFrameworkCore.MySql.Storage.Internal;
using TreinandoPráticasApi._1___Application.Pagination;
using TreinandoPráticasApi.Data.Context;
using TreinandoPráticasApi.Entities;
using TreinandoPráticasApi.Repositories;

namespace TreinandoPráticasApi.Services
{
    public class CategoriaService : Repository<CategoriaEntity>, ICategoria
    {
        public CategoriaService(AppDbContext context) : base(context)
        {
        }

        public PagedList<CategoriaEntity> GetCategorias(CategoriaParameters categoriaParameters)
        {   
            var categorias = Get().OrderBy(p => p.Id).AsQueryable();
            PagedList<CategoriaEntity> categoriasOrdenados = PagedList<CategoriaEntity>.ToPagedList(categorias, categoriaParameters.PageNumber,
                                                                            categoriaParameters.PageSize);
            return categoriasOrdenados;
            }

    
    }
}
