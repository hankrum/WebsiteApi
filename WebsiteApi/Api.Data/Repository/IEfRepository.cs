using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Data.Repository
{
    public interface IEfRepository<T> where T : class
    {
        IQueryable<T> All { get; }

        T Add(T entity);

        T Delete(T entity);

        T Update(T entity);

        Task<T> GetById(long id);
    }
}
