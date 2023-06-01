using movieSeller.DataAccess.Data;
using movieSeller.DataAccess.Repository.IRepository;
using movieSeller.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace movieSeller.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private AppDbContext _context;
        public CategoryRepository(AppDbContext context) : base(context)
        {
            _context = context;

        }
        public void Update(Category obj)
        {
            _context.Categories.Update(obj);
        }
    }
}
