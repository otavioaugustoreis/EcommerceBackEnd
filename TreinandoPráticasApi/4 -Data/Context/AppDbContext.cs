using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TreinandoPráticasApi.Entities;

namespace TreinandoPráticasApi.Data.Context
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :
            base(options)
        {
        }

        public DbSet<UsuarioEntity> _UsuarioEntity { get; set; }
        public DbSet<ProdutoEntity> _ProdutoEntity { get; set; }
        public DbSet<CategoriaEntity> _CategoriaEntity { get; set; }
        public DbSet<PedidoEntity> _PedidoEntity { get; set; }
        public DbSet<PedidoItemEntity> _PedidoItemEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioEntity>().HasKey(u => u.Id);
            modelBuilder.Entity<ProdutoEntity>().HasKey(u => u.Id);
            modelBuilder.Entity<PedidoEntity>().HasKey(u => u.Id);
            modelBuilder.Entity<CategoriaEntity>().HasKey(u => u.Id);
            modelBuilder.Entity<PedidoItemEntity>().HasKey(u => u.Id);




            modelBuilder.Entity<UsuarioEntity>()
                .HasMany(p => p.pedidoEntities)
                .WithOne(u => u.usuarioEntity)
                .HasForeignKey(u => u.UsuarioId);

            modelBuilder.Entity<ProdutoEntity>()
                .HasMany(p => p.pedidoItens)
                .WithOne(p => p.produtoEntity)
                .HasForeignKey(p => p.ProdutoId);

            modelBuilder.Entity<PedidoEntity>()
                .HasMany(p => p.pedidoItems)
                .WithOne(p => p.PedidoEntity)
                .HasForeignKey(p => p.pedidoId);

            modelBuilder.Entity<CategoriaEntity>()
                .HasMany(p => p.produtoEntity)
                .WithOne(u => u.categoriaEntity)
                .HasForeignKey(u => u.Fkcategoria);

            base.OnModelCreating(modelBuilder);
        }
    }
}
