using Microsoft.EntityFrameworkCore;
using MSC.Application.Common.Interfaces.Persistence;
using MSC.Domain.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSC.Infrastructure.Persistence
{
    public class CatalogueRepository : ICatalogueType
    {
        private readonly MedStaCruzContext _context;
        public CatalogueRepository(MedStaCruzContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProductsByCategory(string category)
        {
            if (_context.Products == null)
                throw new DbUpdateException();

            return await _context.Products
                .Where(p => p.Category.Equals(category))
                .ToListAsync();
        }

        //   public Product GetProductById(uint id)
        //   {
        //       if(_context.Products == null)
        //           throw new DbUpdateException();

        //       var product = _context.Products.Find() &&
        //          throw new DbUpdateException();

        //       return product;
        //   }
    }
}
