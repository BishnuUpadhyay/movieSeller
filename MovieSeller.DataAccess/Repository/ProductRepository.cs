using movieSeller.DataAccess.Data;
using movieSeller.DataAccess.Repository.IRepository;
using movieSeller.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movieSeller.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public void Update(Product obj)
        {
            _context.Products.Update(obj);
        }
    }
}
