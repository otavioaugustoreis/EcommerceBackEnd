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

        public  IEnumerable<CategoriaEntity> GetCategorias(CategoriaParameters categoriaParameters)
        {   
            return Get()
                //Ordenadno pelo nome
                  .OrderBy(on => on.DsNome)
                  //Pular os produtos das páginas anteriores
                  .Skip((categoriaParameters.PageNumber -1 ) * categoriaParameters.PageSize)
                  //Selecionar a quantidade de produto especificada pelo tamanho da página
                  .Take(categoriaParameters.PageSize)
                  .ToList();
        }

    
    }
}
