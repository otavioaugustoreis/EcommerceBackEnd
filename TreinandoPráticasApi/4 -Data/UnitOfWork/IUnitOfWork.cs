using TreinandoPráticasApi.Services;

namespace TreinandoPráticasApi.Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        public  IProduto ProdutoRepository       { get; }

        public  ICategoria CategoriaRepository   { get; }

        public  IPedido PedidorRepository        { get;  }

        public PedidoItemService PedidoItemServiceRepository { get;  }

        public  IUsuario UsuarioRepository       { get;  }

        void Commit();
    }
}
