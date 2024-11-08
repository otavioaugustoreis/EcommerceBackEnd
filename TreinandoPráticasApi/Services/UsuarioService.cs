using TreinandoPráticasApi.Data.Context;
using TreinandoPráticasApi.Entities;
using TreinandoPráticasApi.Repositories;

namespace TreinandoPráticasApi.Services
{
    public class UsuarioService : Repository<UsuarioEntity>, IUsuario
    {
        public UsuarioService(AppDbContext context) : base(context)
        {
        } 
    }
}
