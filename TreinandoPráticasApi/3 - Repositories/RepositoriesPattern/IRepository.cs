using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TreinandoPráticasApi.Repositories
{
    public interface IRepository<T>
    {

        public Task<IEnumerable<T?>> GetAsync();
        public Task<T?> GetIdAsync(Expression<Func<T, bool>> predicate);
        public IEnumerable<T> Get();
        public T GetId(Expression<Func<T, bool>> predicate);
        public T Post(T entidade);
        public T Put(T entidade);
        public T Delete(T entidade);
    }
}
