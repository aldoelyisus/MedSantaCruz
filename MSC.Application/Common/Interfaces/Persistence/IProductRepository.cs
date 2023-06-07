using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MSC.Domain.Product;


namespace MSC.Application.Common.Interfaces.Persistence
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProductById(uint id);
        Task Add(Product product);
        Task Edit(Product product);
        Task Delete(uint id);
    }
}
