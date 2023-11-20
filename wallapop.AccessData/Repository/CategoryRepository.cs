using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wallapop.AccessData.DbContext;
using wallapop.AccessData.Repository.IRepository;
using wallapop.Models.Models;

namespace wallapop.AccessData.Repository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Category category)
        {
            var categoryDB = Entities.FirstOrDefault(x => x.Id == category.Id);

            if (categoryDB != null)
            {
                categoryDB.Id = category.Id;
                categoryDB.Name = category.Name;

                _context.SaveChanges();
            }
        }
    }
}
