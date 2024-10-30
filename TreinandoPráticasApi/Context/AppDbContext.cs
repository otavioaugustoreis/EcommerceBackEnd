using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TreinandoPráticasApi.Entities;

namespace TreinandoPráticasApi.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : 
            base(options) 
        { 
        }
        
        public DbSet<UsuarioEntity>   _UsuarioEntity     { get; set; }
        public DbSet<ProdutoEntity>   _ProdutoEntity     { get; set; }
        public DbSet<CategoriaEntity> _CategoriaEntity   { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioEntity>()
                .HasMany(p => p.produtoEntity)
                .WithOne(u => u.usuarioEntity)
                .HasForeignKey(u => u.FkUsuario);

            modelBuilder.Entity<CategoriaEntity>()
                .HasMany(p => p.produtoEntity)
                .WithOne(u => u.categoriaEntity)
                .HasForeignKey(u => u.Fkcategoria);
        }
    }
}
