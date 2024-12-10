using Microsoft.CodeAnalysis.Operations;
using TreinandoPráticasApi.Data.Context;
using TreinandoPráticasApi.Services;

namespace TreinandoPráticasApi.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext dbContext;

        private ICategoria categoria;
        private IProduto produto;
        private IUsuario usuario;
        private IPedido pedido;
        private PedidoItemService pedidoItem;

        public UnitOfWork(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public UnitOfWork() { }

        public IProduto ProdutoRepository 
        {
            get 
            {
                return produto = produto ?? new ProdutoService(dbContext);
            } 
        }

        public ICategoria CategoriaRepository
        {
            get
            {
                return categoria = categoria ?? new CategoriaService(dbContext);
            }
        }

        public IPedido PedidorRepository
        {
            get
            {
                return pedido = pedido ?? new PedidoService(dbContext);
            }
        }

        public PedidoItemService PedidoItemServiceRepository
        {
            get
            {
                return pedidoItem = pedidoItem ?? new PedidoItemService(dbContext);
            }
        }

        public IUsuario UsuarioRepository
        {
            get
            {
                return usuario = usuario ?? new UsuarioService(dbContext);
            }
        }

        public  void Commit()
        {
            throw new NotImplementedException();
        }
    }
}
