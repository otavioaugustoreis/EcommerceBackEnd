﻿using Microsoft.AspNetCore.Mvc;

namespace TreinandoPráticasApi.RepositoriesPattern
{
    public interface IControllerPattern<T> where T : class
    {
        public ActionResult<IEnumerable<T>> Get();
        public ActionResult<T> GetId(int id);
        public ActionResult<T> Post(T entidade);
        public ActionResult<T> Put(int id, T t);
        public ActionResult<T> Delete(int id);
    }
}
