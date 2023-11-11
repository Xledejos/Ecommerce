using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using wallapop.AccessData.DbContext;
using wallapop.AccessData.Repository.IRepository;

namespace wallapop.AccessData.Repository
{
    public class GenericRepository<T> : IGenericRepository<T>
        where T : class
    {
        private readonly ApplicationDbContext _context;
        protected DbSet<T> Entities => _context.Set<T>();

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filtro = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null, bool isTracking = true)
        {
            throw new NotImplementedException();
        }

        public async Task<T?> GetById(int id)
            => await Entities.FindAsync(id);

        public Task<T> GetFirst(Expression<Func<T, bool>> filtro = null, string includeProperties = null, bool isTracking = true)
        {
            throw new NotImplementedException();
        }

        public async Task Insert(T entity)
        {
            await Entities.AddAsync(entity);
        }

        public void Remove(T entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            throw new NotImplementedException();
        }
    }
}
