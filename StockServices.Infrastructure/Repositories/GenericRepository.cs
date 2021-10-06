using Microsoft.EntityFrameworkCore;
using StockServices.Core.Contracts;
using StockServices.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StockServices.Infrastructure.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly StocksContext context;

        public GenericRepository(StocksContext context)
        {
            this.context = context;
        }
        public T Add(T item)
        {
            return context.Add(item).Entity;
        }

        public T Delete(T item)
        {
            return context.Remove(item).Entity;
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> condition = null, string includes = null)
        {
            var Items = context.Set<T>().AsQueryable();
            if (includes != null)
            {
                var NavigationProperties = includes.Split(',');
                foreach (var NavigationProperty in NavigationProperties)
                {
                    Items = Items.Include(NavigationProperty);
                }
            }

            
            if(condition!=null)
            {
                Items = Items.Where(condition);
            }
            return await Items.ToListAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }

        public T Update(T item)
        {
            return context.Update(item).Entity;
        }
    }
}
