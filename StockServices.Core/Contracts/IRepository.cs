using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StockServices.Core.Contracts
{
    public interface IRepository<T>: IDisposable where T :class 
    {
        T Add(T item);
        T Update(T item);
        T Delete(T item);
        Task<int> SaveAsync();
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> condition = null, string includes = null);
    }
}
