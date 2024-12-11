using TreinandoPráticasApi.Controllers;
using TreinandoPráticasApi.Data.Context;
using TreinandoPráticasApi.Entities;

namespace TreinandoPráticasApi._4__Data
{
    public class SeedingServiceData
    {
        private AppDbContext _context;

        public SeedingServiceData(AppDbContext context)
        {
            _context = context;
        }

        public void Seeding()
        {
            if (_context._CategoriaEntity.Any() ||
               _context._ProdutoEntity.Any())
            {
                return;
            }

            var categoria1 = new CategoriaEntity(1, "Eletrônicos", "imagem_eletronicos.jpg");
            var categoria2 = new CategoriaEntity(2, "Roupas", "imagem_roupas.jpg");
            var categoria3 = new CategoriaEntity(3, "Livros", "imagem_livros.jpg");
            var categoria4 = new CategoriaEntity(4, "Móveis", "imagem_moveis.jpg");
            var categoria5 = new CategoriaEntity(5, "Brinquedos", "imagem_brinquedos.jpg");

            var produto1 = new ProdutoEntity(1, "Smartphone", 50) { categoriaEntity = categoria1, Fkcategoria = categoria1.Id };
            var produto2 = new ProdutoEntity(2, "Laptop", 30) { categoriaEntity = categoria1, Fkcategoria = categoria1.Id };
            var produto3 = new ProdutoEntity(3, "Camiseta", 100) { categoriaEntity = categoria2, Fkcategoria = categoria2.Id };
            var produto4 = new ProdutoEntity(4, "Calça Jeans", 60) { categoriaEntity = categoria2, Fkcategoria = categoria2.Id };
            var produto5 = new ProdutoEntity(5, "Livro de Ficção", 40) { categoriaEntity = categoria3, Fkcategoria = categoria3.Id };
            var produto6 = new ProdutoEntity(6, "Enciclopédia", 15) { categoriaEntity = categoria3, Fkcategoria = categoria3.Id };
            var produto7 = new ProdutoEntity(7, "Mesa de Escritório", 10) { categoriaEntity = categoria4, Fkcategoria = categoria4.Id };
            var produto8 = new ProdutoEntity(8, "Cadeira Gamer", 25) { categoriaEntity = categoria4, Fkcategoria = categoria4.Id };
            var produto9 = new ProdutoEntity(9, "Quebra-Cabeça", 75) { categoriaEntity = categoria5, Fkcategoria = categoria5.Id };
            var produto10 = new ProdutoEntity(10, "Carrinho de Controle Remoto", 40) { categoriaEntity = categoria5, Fkcategoria = categoria5.Id };

            _context._CategoriaEntity.AddRange(categoria1, categoria2, categoria3, categoria4, categoria5);

            _context._ProdutoEntity.AddRange(produto1, produto2, produto3, produto4, produto5, produto6, produto7, produto8, produto9, produto10);

            _context.SaveChanges();
        }

    }
}
