using Microsoft.EntityFrameworkCore;
using TreinandoPráticasApi.Entities;

namespace TreinandoPráticasApi.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<UsuarioEntity> ClienteEntity { get; set; }
    }
}
