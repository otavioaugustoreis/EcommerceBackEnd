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

        public PagedList<CategoriaEntity> GetCategoriasAsync(CategoriaParameters categoriaParameters)
        {
            //Aqui está a operação assíncrona
            var categorias =  Get();
            //Aqui está a operação sincrona feita na memória 
            var categoriaOrdenada = categorias.OrderBy(p => p.Id).AsQueryable();

            PagedList<CategoriaEntity> resultado = PagedList<CategoriaEntity>.ToPagedList(categoriaOrdenada, categoriaParameters.PageNumber,
                                                                            categoriaParameters.PageSize);
            return resultado;
            }

    
    }
}
