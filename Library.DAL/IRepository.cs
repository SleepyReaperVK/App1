using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL
{
    public interface IRepository<T>
    {
        T Add(T item);
        IQueryable<T> Get();
        T Get(Guid id);
        T Update(T item);
        T Delete(Guid id);
    }
}
