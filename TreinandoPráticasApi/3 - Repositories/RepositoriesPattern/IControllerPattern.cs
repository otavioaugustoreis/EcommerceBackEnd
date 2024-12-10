using Microsoft.AspNetCore.Mvc;

namespace TreinandoPráticasApi.RepositoriesPattern
{
    public interface IControllerPattern<T>
    {
        public ActionResult<IEnumerable<T>> Get();
        public IActionResult GetId(int id);
        public ActionResult<T> Post(T entidade);
        public ActionResult<T> Put(int id, T t);
        public ActionResult<T> Delete(int id);
    }
}
