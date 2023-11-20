using wallapop.AccessData.DbContext;
using wallapop.AccessData.Repository.IRepository;

namespace wallapop.AccessData.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public ICategoryRepository CatRepo { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            CatRepo = new CategoryRepository(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
