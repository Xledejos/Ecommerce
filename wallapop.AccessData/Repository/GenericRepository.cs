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

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filtro = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null, bool isTracking = true)
        {
            IQueryable<T> query = Entities;

            if(filtro != null)
            {
                query = query.Where(filtro);
            }

            if(includeProperties != null)
            {
                foreach(var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if(orderBy != null)
            {
                query = orderBy(query);
            }

            if (!isTracking)
            {
                query = query.AsNoTracking();
            }

            return await query.ToListAsync();
        }

        public async Task<T?> GetById(int id)
            => await Entities.FindAsync(id);

        public async Task<T> GetFirst(Expression<Func<T, bool>> filtro = null, string includeProperties = null, bool isTracking = true)
        {
            IQueryable<T> query = Entities;

            if (filtro != null)
            {
                query = query.Where(filtro);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (!isTracking)
            {
                query = query.AsNoTracking();
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task Insert(T entity)
        {
            await Entities.AddAsync(entity);
        }

        public void Remove(T entity)
        {
            Entities.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            Entities.RemoveRange(entity);
        }
    }
}
