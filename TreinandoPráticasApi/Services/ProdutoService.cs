using Microsoft.EntityFrameworkCore;
using TreinandoPráticasApi.Context;
using TreinandoPráticasApi.Entities;
using TreinandoPráticasApi.Repositories;

namespace TreinandoPráticasApi.Services
{
    public class ProdutoService : Repository<ProdutoEntity>, IProduto
    {
        public ProdutoService(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<ProdutoEntity> ProdutoPorCategoria(int id)
        {

            return Get().Where(x => x.Id == id);
            //    .FromSql($"SELECT * FROM TB_PRODUTOS WHERE pk_id = {id}")
            //    .ToList();
            // Testar desse jeito
            //return _context._ProdutoEntity
            //    .FromSql($"SELECT * FROM TB_PRODUTOS WHERE pk_id = {id}")
            //    .ToList();
        }
    }
}
